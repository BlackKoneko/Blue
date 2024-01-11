using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        NONE,
        START,
    }
    public TileType tileType;
    public int value;
    public bool moveable;
    public TileNode tileNode;

    private void Awake()
    {
        tileNode = new TileNode(value);

        GameManager.instance.nextTurnAction += () => { moveable = false; };
        //스태틱 이면 컴파일타임에 생성 되므로 문제 없음
        //다만 스태틱 아닌경우는 생성 되는 순서가 모호해 지므로 문제 발생 가능성 있음(비추천)
    }
}
