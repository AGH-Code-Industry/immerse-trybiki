using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour {
    protected Enemy _baseEnemy;
    
    protected virtual void Awake() {
        _baseEnemy = GetComponent<Enemy>();
    }
    
    public abstract void Attack(IDamageable target);
    public abstract void LostTarget();
}
