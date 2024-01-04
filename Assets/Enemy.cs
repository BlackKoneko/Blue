using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private float hp;
    public override float Hp
    {
        get { return hp; }
        set { hp = value; } 
    }
    private float atk;
    
}
