using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyMovement : MonoBehaviour {
    protected Enemy _baseEnemy;

    protected bool _aiming;
    
    protected virtual void Awake() {
        _baseEnemy = GetComponent<Enemy>();
    }

    public abstract void Move();
    public abstract void SetTarget(IDamageable target);
    public abstract void LostTarget();

    public void StartAiming() {
        _aiming = true;
    }

    public void StopAiming() {
        _aiming = false;
    }
}
