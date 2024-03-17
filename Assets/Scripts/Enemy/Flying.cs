using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : EnemyMovement {
    private Transform _target;
    private Rigidbody2D _rigidbody2D;
    
    
    protected override void Awake() {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void Move() {
        if (_aiming || stunned)
            return;
        
        // Debug.Log(_target.position);
        // _rigidbody2D.MovePosition(_target.position * (Time.fixedDeltaTime * _baseEnemy.Speed));
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _baseEnemy.Speed * Time.fixedDeltaTime) + Vector2.up * (Time.fixedDeltaTime * Random.Range(-0.5f, 0.5f));
    }

    public override void SetTarget(IDamageable target) {
        _target = target.GetTransform();
    }

    public override void LostTarget() {
        _target = null;
    }
}
