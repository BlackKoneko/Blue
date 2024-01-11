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

public class MissionManager : Singleton<MissionManager>
{
    public Tile[] moveTile;
    public LayerMask TileLayer;
    public Graph graph;
    public Dictionary<int, TileNode> tileNodeDic;
    public GameObject plObj;

    public void SetMission()
    {
        graph = new Graph();
        tileNodeDic = new Dictionary<int, TileNode>();
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

        GameManager.instance.nextTurnAction += () => { SetMoveTile(); }; //다음 턴 버튼 클릭시 이동 가능한 타일이 변경 


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            MouseClick();
    }

    public void MouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, TileLayer))
        {
            if (hit.transform.TryGetComponent(out Tile tile))
            {
                if(tile.tileType == Tile.TileType.START)
                {
                    GameManager.instance.plPoint = tile;
                    UIManager.instance.CharacterSelect();
                }
                else
                {
                    if(tile.moveable)
                    {
                        GameManager.instance.plPoint = tile;
                        plObj = GameManager.instance.playerObj;
                        plObj.transform.position = tile.transform.position;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 플레이어가 갈 수 있는 간선을 가져오는 함수
    /// </summary>
    /// <param name="plPoint"> 플레이어가 서있는 타일</param>
    /// <returns></returns>
    public List<Edge> GetEdgeList(int plPoint)
    {
        List<Edge> edesList = new List<Edge>();
        foreach (Edge edge in graph.nodeList[plPoint-1].egdesInNode)
        {
            edesList.Add(edge);
            Debug.Log("이동 가능한 값"+ edge.eNode.value);
        }
        return edesList;
    }

    /// <summary>
    /// 이동 가능한 타일에 bool값을 true로 변경해줌. - 플레이어가 인접 타일로 한칸 이동하기 위해서 구현.
    /// </summary>
    public void SetMoveTile()
    {
        List<Edge> list = GetEdgeList(GameManager.instance.plPoint.value);
        for (int i = 0; i<list.Count; i++)
            moveTile[list[i].eNode.value -1].moveable = true; //설정
    }

}
