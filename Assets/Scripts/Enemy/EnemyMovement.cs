using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Compilation;
#endif
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyMovement : MonoBehaviour {
    protected Enemy _baseEnemy;

    protected bool _aiming;
    protected bool stunned;
    
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
    
    public void Stun() {
        stunned = true;
    }

    public void UnStun() {
        stunned = false;
    }
}
