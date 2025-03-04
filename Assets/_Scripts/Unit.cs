using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IMoveable, IAttackable
{
    public float Speed { get; set; } = 3f;
    public bool MovingRight { get; set; } = true;
    public Transform AttackPoint { get; set; }
    public float AttackRange { get; set; } = 5f;
    public float AttackRate { get; set; } = 1f;

    private Rigidbody2D _rb;

    private bool _isAttacking;
    private float _nextAttackTime = 0f;
    private Animator _animator;

    protected float _moveDirection;
    protected Vector2 _attackDirection;
    protected int _targetLayerMask;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        AttackPoint = transform.Find("AttackPoint");
    }

    protected virtual void Start()
    {
        CheckSpriteFlipping();
    }

    private void FixedUpdate()
    {
        CheckDirection();
        Move();
        Attack();
    }

    private void CheckSpriteFlipping()
    {
        if (!MovingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckDirection()
    {
        if(MovingRight)
        {
            _moveDirection = 1f;
            _attackDirection = Vector2.right;
        }
        else
        {
            _moveDirection = -1f;
            _attackDirection = Vector2.left;
        }
    }

    public void Move()
    {
        float moveSpeed = _isAttacking ? 0f : Speed;
        _rb.velocity = new Vector2(_moveDirection * moveSpeed, _rb.velocity.y);
    }

    public bool HaveAnyTargetInAttackRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _attackDirection, AttackRange , _targetLayerMask);

        Debug.DrawRay(transform.position, _attackDirection * AttackRange, Color.red);

        return hit.collider != null;
    }

    public void Attack()
    {
        if(HaveAnyTargetInAttackRange() && Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + AttackRate;
            OnAttack();
        }

        if (!HaveAnyTargetInAttackRange())
        {
            _animator.SetBool("Attacking", false);
            _isAttacking = false;
        }
    }

    protected virtual void OnAttack()
    {
        _animator.SetBool("Attacking", true);
        _isAttacking = true;
    }
}
