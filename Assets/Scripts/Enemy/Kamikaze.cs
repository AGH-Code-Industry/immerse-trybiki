using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : EnemyAttack {
    
    private IDamageable _target;
    
    public override void Attack(IDamageable target) {
        Explode();
    }
    
    public override void SetTarget(IDamageable target) {
        _target = target;
    }

    public override void LostTarget() {
        _target = null;
    }

    private void Explode() {
        _target.TakeDamage(_baseEnemy.AttackDamage);
        Destroy(gameObject);
    }
}
