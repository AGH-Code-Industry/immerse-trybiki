using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : EnemyMovement {
    private const float Epsilon = 0.1f;
    
    [SerializeField] private List<Transform> _points;
    
    private Transform _target;
    private int _targetPoint;

    private bool _canMove;

    protected override void Awake() {
        base.Awake();
        _canMove = true;
        _targetPoint = 0;
        _target = _points[_targetPoint];
    }

    public override void Move() {
        if (!_canMove)
            return;
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _baseEnemy.Speed * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, _target.position) < Epsilon && _baseEnemy.EnemyState != EnemyState.Attacking) {
            SetPointTarget();
        }
    }

    private void SetPointTarget() {
        _target = _points[++_targetPoint % _points.Count];

    }

    public override void SetTarget(IDamageable target) {
        _target = target.GetTransform();
    }

    public override void LostTarget() {
        SetPointTarget();
    }

    private void ToggleMovementAbility(bool canMove) {
        _canMove = canMove;
    }
}
