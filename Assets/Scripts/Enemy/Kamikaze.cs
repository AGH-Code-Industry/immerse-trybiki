using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : EnemyAttack {
    private bool _checkDistance;

    [SerializeField] private float _kamikazeDistance;
    
    private IDamageable _target;

    protected override void Awake() {
        base.Awake();
        _checkDistance = false;
    }

    public override void Attack(IDamageable target) {
        _target = target;
        _checkDistance = true;
    }

    private void Update() {
        if (!_checkDistance)
            return;

        if (Vector2.Distance(transform.position, _target.GetTransform().position) < _kamikazeDistance) {
            Explode();
        }
    }

    private void Explode() {
        _target.TakeDamage(_baseEnemy.AttackDamage);
        Destroy(gameObject);
    }
}
