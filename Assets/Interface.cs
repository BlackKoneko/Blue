using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
    float Hp { get; set; }
    public void Hit(IAttackable attacker);
}
public interface IAttackable
{
    float Atk { get; set; }
    public void Attack(IHitable target);
}
