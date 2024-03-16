using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyMovement : MonoBehaviour {
    protected Enemy _baseEnemy;
    
    private void Awake() {
        _baseEnemy = GetComponent<Enemy>();
    }

    public abstract void Move();
    public abstract void SetTarget(IDamageable target);
}
