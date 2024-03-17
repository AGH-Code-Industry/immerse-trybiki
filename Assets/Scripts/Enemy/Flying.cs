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
        transform.eulerAngles = new Vector3(0f, _target.transform.position.x - transform.position.x > 0 ? 0 : 180, 0f);
        
        if (_aiming || stunned)
            return;

        _rigidbody2D.MovePosition(transform.position + (_target.position - transform.position )* (Time.fixedDeltaTime * _baseEnemy.Speed));
    }

    public override void SetTarget(IDamageable target) {
        _target = target.GetTransform();
    }

    public override void LostTarget() {
        _target = null;
    }
}
