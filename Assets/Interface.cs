using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHitable
{
    float Hp { get; set; }
    public void Hit(IAttackable attacker);
}
interface IAttackable
{
    float Atk { get; set; }
    public void Attack(IHitable target);
}
