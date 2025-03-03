using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    protected override void Start()
    {
        _targetLayerMask = LayerMask.GetMask("Ally");
        MovingRight = false;
        base.Start();
    }
}
