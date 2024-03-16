using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour {
    protected Enemy _baseEnemy;
    
    private void Awake() {
        _baseEnemy = GetComponent<Enemy>();
    }
    
    public abstract void Attack(IDamageable target);
}
