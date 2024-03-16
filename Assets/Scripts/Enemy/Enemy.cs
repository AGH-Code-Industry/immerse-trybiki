using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour, IDamageable {
    [SerializeField] private EnemySO _enemySO;
    
    private EnemyMovement _movementModule;
    private EnemyAttack _enemyAttack;

    public float HP => _hp;
    public float Speed => _speed;
    public AttackType AttackType => _attackType;
    public float AttackDamage => _attackDamage;
    
    private float _hp;
    private float _attackDamage;
    private float _timeMultiplayer;
    private AttackType _attackType;
    private float _speed;

    protected virtual void Awake() {
        _enemyAttack = GetComponent<EnemyAttack>();
        _movementModule = GetComponent<EnemyMovement>();
        _hp = _enemySO.hp;
        _attackDamage = _enemySO.attackDamage;
        _timeMultiplayer = _enemySO.timeMultiplayer;
        _attackType = _enemySO.attackType;
        _speed = _enemySO.speed;
    }

    protected virtual void TakeDamage(int amount) {
        _hp -= amount;
        if (_hp <= 0) {
            Death();    
        }
    }

    public void TakeDamage(float amount) {
        _hp -= amount;
        if (_hp <= 0) {
            Death();
        }
    }

    public Transform GetTransform() {
        return transform;
    }

    private void Death() {
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        _movementModule.Move();
    }

    public void SetTarget(IDamageable target) {
        _movementModule.SetTarget(target);
    }

    public void Attack(IDamageable target) {
        _enemyAttack.Attack(target);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // SetTarget(other.GetComponent<Player>());
        }
    }


    // protected virtual void 
    
    
}
