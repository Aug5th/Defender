using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    float Speed { get; set; }
    bool MovingRight { get; set; }
    void Move();
}
