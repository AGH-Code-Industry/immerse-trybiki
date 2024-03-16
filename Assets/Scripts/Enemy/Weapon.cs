using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : EnemyAttack {
    private IDamageable _target;
    [SerializeField] private GameObject _gearPrefab;
    
    public override void SetTarget(IDamageable target) {
        _target = target;
    }

    public override void Attack(IDamageable target) {
        Instantiate(_gearPrefab, transform.position, transform.rotation).GetComponent<GearByEnemy>().ThrowGear(_target.GetTransform().position, _baseEnemy.AttackForce, _baseEnemy.AttackDamage);
    }

    public override void LostTarget() {
        _target = null;
    }
}
