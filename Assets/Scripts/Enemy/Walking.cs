using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : EnemyMovement {
    private const float Epsilon = 0.5f;
    
    [SerializeField] private List<Transform> _points;
    
    private Transform _target;
    private int _targetPoint;

    private bool _canMove;

    protected override void Awake() {
        base.Awake();
        _canMove = true;
        _targetPoint = 0;
        bool find = false;
        RaycastHit2D[] recastHit2D = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach (RaycastHit2D recastHit in recastHit2D) {
            if (recastHit.transform.gameObject.TryGetComponent(out Platform platform)) {
                _points = platform._points;
                find = true;
                break;
            }
        }
        if (!find) {
            Destroy(gameObject);
        }
        _target = _points[_targetPoint];
    }

    public override void Move() {
        if (!_canMove || stunned)
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
}
