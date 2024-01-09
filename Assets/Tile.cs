using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int value;
    public List<Edge> egdesInNode;
    public Tile(int value)
    {
        this.value = value;
        egdesInNode = new List<Edge>();
    }
}
