using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : EnemyMovement {
    private Transform _target;
    
    public override void Move() {
        
    }

    public override void SetTarget(IDamageable target) {
        _target = target.GetTransform();
    }

    public override void LostTarget() {
        _target = null;
    }
}
