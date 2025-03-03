using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        Debug.Log("Take damage :" + amount);
    }
}
