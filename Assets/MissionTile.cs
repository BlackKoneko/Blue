using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Edge : IComparable<Edge>
{
    public Tile sNode;
    public Tile eNode;
    public int cost;

    public Edge(Tile sNode, Tile eNode, int cost)
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
    public List<Tile> nodeList;
    public List<Edge> edgeList;
    public Dictionary<Tile, bool> hasNodeChecDic;

    public Graph()
    {
        nodeList = new List<Tile>();
        edgeList = new List<Edge>();
        hasNodeChecDic = new Dictionary<Tile, bool>();
    }

    public void AddEdge(Tile sNode, Tile eNode, int cost)
    {
        TryAddNode(sNode);
        TryAddNode(eNode);

        Edge newEdge = new Edge(sNode, eNode, cost);

        edgeList.Add(newEdge);
        sNode.egdesInNode.Add(newEdge);
    }
    public void AddEdge(Edge edge)
    {
        AddEdge(edge.sNode, edge.eNode, edge.cost);
        AddEdge(edge.eNode, edge.sNode, edge.cost);
    }

    bool TryAddNode(Tile node)
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
    public Graph graph1;
    public Graph graph2;
    public Graph graph3;
    public Graph graph4;
    public Dictionary<int, Tile> tileNodeDic;
    public Dictionary<int, Graph> missionDic;
    public GameObject plObj;

    private void Awake()
    {
        graph1 = new Graph();
        tileNodeDic = new Dictionary<int, Tile>();
        missionDic = new Dictionary<int, Graph>();
        tileNodeDic.Add(1, moveTile[0]);
        tileNodeDic.Add(2, moveTile[1]);
        tileNodeDic.Add(3, moveTile[2]);
        graph1.AddEdge(tileNodeDic[1], tileNodeDic[2], 1);
        graph1.AddEdge(tileNodeDic[2], tileNodeDic[3], 1);
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
            if(hit.transform.gameObject.name == "StartTile" && GameManager.instance.gameStartBool == false)
            {
                GameManager.instance.startPoint = hit.transform.gameObject;
                UIManager.instance.CharacterSelect();  
            }
            if(GameManager.instance.gameStartBool == true)
            {
                if(hit.transform.TryGetComponent(out Enemy enemy))
                {
                    plObj = enemy.gameObject;
                }
                else if(hit.transform.TryGetComponent(out Tile tile))
                {
                    
                }
            }
        }
    }
    

}
