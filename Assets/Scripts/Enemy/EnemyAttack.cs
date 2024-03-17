using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour {
    protected Enemy _baseEnemy;

    protected bool stunned;
    
    protected virtual void Awake() {
        _baseEnemy = GetComponent<Enemy>();
    }

    public abstract void SetTarget(IDamageable target);
    public abstract void Attack(IDamageable target);
    public abstract void LostTarget();

    public void Stun() {
        stunned = true;
    }

    public void UnStun() {
        stunned = false;
    }
}
