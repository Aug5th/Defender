using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Unit
{
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _bulletSpeed = 5f;

    protected override void Start()
    {
        _targetLayerMask = LayerMask.GetMask("Enemy");
        base.Start();
    }

    protected override void OnAttack()
    {
        if (_bulletPrefab != null)
        {
            GameObject bullet = Instantiate(_bulletPrefab, AttackPoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if(bulletRb != null )
            {
                bulletRb.velocity = new Vector2(_moveDirection * _bulletSpeed, 0f);
            }
        }
        base.OnAttack();
    }
}
