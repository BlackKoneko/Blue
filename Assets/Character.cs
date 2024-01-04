using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHitable, IAttackable
{
    public virtual float Hp { get ; set ; }
    public virtual float Atk { get ; set ; }

    void IAttackable.Attack(IHitable target)
    {
        throw new System.NotImplementedException();
    }

    void IHitable.Hit(IAttackable attacker)
    {
        throw new System.NotImplementedException();
    }
}
