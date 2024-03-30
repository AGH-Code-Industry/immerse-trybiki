using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : EnemyMovement {
    private const float Epsilon = 0.5f;
    
    [SerializeField] private List<Transform> _points;
    
    private Transform _target;
    private int _targetPoint;
    private Platform _platform;

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
                _platform = platform;
                transform.position = new Vector3(_points[0].position.x, _points[0].position.y + 2f, _points[0].position.z);
                break;
            }
        }
        if (!find) {
            Destroy(gameObject);
        }

    }

    private void Update() {
        if (!_platform)
            return;
        _points = _platform._points;
        _target = _points[_targetPoint];
    }

    public override void Move() {
        transform.eulerAngles = new Vector3(0f, _target.transform.position.x - transform.position.x > 0 ? 0 : 180, 0f);

        if (!_canMove || stunned)
            return;
        Debug.Log(_target.position);
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
