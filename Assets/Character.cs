using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHitable, IAttackable
{
    public abstract float Hp { get ; set ; }
    public abstract float Atk { get ; set ; }

    public abstract void Attack(IHitable target);

    public abstract void Hit(IAttackable attacker);
}
