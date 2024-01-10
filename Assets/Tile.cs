using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
