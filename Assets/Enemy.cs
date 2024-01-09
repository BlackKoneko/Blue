using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private float hp;
    public override float Hp
    {
        get { return hp; }
        set 
        { 
            hp = value; 
            if(hp < 0)
            {
                GameManager.instance.enemyOP.Return(gameObject, 0);
            }
        } 
    }
    private float atk;

    public override float Atk { get { return atk; } set { atk = value; } }

    public override void Attack(IHitable target)
    {
        target.Hp -= Atk;
    }

    public override void Hit(IAttackable attacker)
    {
        Hp -= attacker.Atk;
    }


}
