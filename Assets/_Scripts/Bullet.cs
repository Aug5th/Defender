using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform AttackPoint;

    private void FixedUpdate()
    {
        HandleImpact();
    }

    private void HandleImpact()
    {
        int layerMask = LayerMask.GetMask("Enemy");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, layerMask);

        if (hit.collider == null)
        {
            return;
        }

        IDamageable damageable = hit.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(2);
            Destroy(gameObject);
        }
    }
}
