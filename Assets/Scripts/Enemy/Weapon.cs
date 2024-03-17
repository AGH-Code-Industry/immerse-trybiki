using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : EnemyAttack {
    private IDamageable _target;
    
    public override void SetTarget(IDamageable target) {
        _target = target;
    }

    public override void Attack(IDamageable target) {
        //Debug.Log("Dupa");
    }

    public override void LostTarget() {
        _target = null;
    }
}
