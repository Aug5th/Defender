using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    Transform AttackPoint { get; set; }
    float AttackRange { get; set; }
    float AttackRate { get;  set; }
    bool HaveAnyTargetInAttackRange();
    void Attack();
}
