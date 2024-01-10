using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class TileNode
{
    public int value;
    public List<Edge> egdesInNode;
    public TileNode(int value)
    {
        this.value = value;
        egdesInNode = new List<Edge>();
    }
}
public class Edge : IComparable<Edge>
{
    public TileNode sNode;
    public TileNode eNode;
    public int cost;

    public Edge(TileNode sNode, TileNode eNode, int cost)
    {
        this.sNode = sNode;
        this.eNode = eNode;
        this.cost = cost;
    }

    public int CompareTo(Edge other)
    {
        if (cost > other.cost)
            return 1;
        else if (cost < other.cost)
            return -1;

        return 0;
    }
}
public class Graph
{
    public List<TileNode> nodeList;
    public List<Edge> edgeList;
    public Dictionary<TileNode, bool> hasNodeChecDic;

    public Graph()
    {
        nodeList = new List<TileNode>();
        edgeList = new List<Edge>();
        hasNodeChecDic = new Dictionary<TileNode, bool>();
    }

    public void AddEdge(TileNode sNode, TileNode eNode, int cost)
    {
        TryAddNode(sNode);
        TryAddNode(eNode);

        Edge newSEdge = new Edge(sNode, eNode, cost);
        Edge newEEdge = new Edge(eNode, sNode, cost);

        edgeList.Add(newSEdge);
        edgeList.Add(newEEdge);
        

        sNode.egdesInNode.Add(newSEdge);
        eNode.egdesInNode.Add(newEEdge);
    }
    public void AddEdge(Edge edge)
    {
        AddEdge(edge.sNode, edge.eNode, edge.cost);
    }

    bool TryAddNode(TileNode node)
    {
        if (hasNodeChecDic.ContainsKey(node) == false)
        {
            hasNodeChecDic[node] = true;
            nodeList.Add(node);
            return true;
        }
        return false;
    }
}

public class MissionTile : MonoBehaviour
{
    public Tile[] moveTile;
    public LayerMask TileLayer;
    public Graph graph;
    public Dictionary<int, TileNode> tileNodeDic;
    public GameObject plObj;

    private void Start()
    {
        graph = new Graph();
        tileNodeDic = new Dictionary<int, TileNode>();
        Debug.Log(GameManager.instance.MissionNum);
        switch(GameManager.instance.MissionNum)
        {
            case 1:
                tileNodeDic.Add(1, moveTile[0].tileNode);
                tileNodeDic.Add(2, moveTile[1].tileNode);
                tileNodeDic.Add(3, moveTile[2].tileNode);
                graph.AddEdge(tileNodeDic[1], tileNodeDic[2], 1);
                graph.AddEdge(tileNodeDic[2], tileNodeDic[3], 1);
                break;
            case 2:
                break;
        }
 
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnMouseDown();
    }

    public void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, TileLayer))
        {
            if (hit.transform.TryGetComponent(out Tile tile))
            {
                if(tile.tileType == Tile.TileType.START)
                {
                    GameManager.instance.startPoint = tile;
                    UIManager.instance.CharacterSelect();
                }
            }
            else if (GameManager.instance.gameStartBool)
            {

            }
        }
    }
    public List<Edge> MoveAble(int plPoint)
    {
        List<Edge> edesList = new List<Edge>();
        foreach (Edge edge in graph.nodeList[plPoint].egdesInNode)
        {
            edesList.Add(edge);
            Debug.Log(edge.eNode.value);
        }
        return edesList;
    }

}
