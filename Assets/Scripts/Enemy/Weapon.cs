using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : EnemyAttack
{
    public override void SetTarget(IDamageable target) {
        throw new System.NotImplementedException();
    }

    public override void Attack(IDamageable target) {
        throw new System.NotImplementedException();
    }

    public override void LostTarget() {
        throw new System.NotImplementedException();
    }
}
