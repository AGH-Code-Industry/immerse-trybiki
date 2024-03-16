using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    Idle,
    Following,
    Attacking
}

// [RequireComponent(typeof(EnemyMovement))]
// [RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour, IDamageable {
    [SerializeField] private EnemySO _enemySO;
    
    private EnemyMovement _movementModule;
    private EnemyAttack _enemyAttack;

    public EnemyState EnemyState => _enemyState;
    public float HP => _hp;
    public float Speed => _speed;
    public AttackType AttackType => _attackType;
    public float AttackDamage => _attackDamage;
    public float AttackDistance => _attackDistance;
    
    private float _hp;
    private float _attackDamage;
    private float _timeMultiplayer;
    private AttackType _attackType;
    private float _speed;
    private float _caughtDistance;
    private float _attackDistance;

    private IDamageable _target;
    private EnemyState _enemyState;

    protected virtual void Awake() {
        _enemyAttack = GetComponent<EnemyAttack>();
        _movementModule = GetComponent<EnemyMovement>();
        _hp = _enemySO.hp;
        _attackDamage = _enemySO.attackDamage;
        _timeMultiplayer = _enemySO.timeMultiplayer;
        _attackType = _enemySO.attackType;
        _speed = _enemySO.speed;
        _caughtDistance = _enemySO.caughtDistance;
        _attackDistance = _enemySO.attackDistance;
    }

    private void Update() {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.instance.transform.position);
        if (_target == null) {
            if (distanceToPlayer < _caughtDistance || Math.Abs(_caughtDistance - (-1)) < 0.1f) {
                CaughtPlayer();        
            }
        }
        else {
            if (distanceToPlayer > _caughtDistance) {
                LostPlayer();
            }
            else if (distanceToPlayer < _attackDistance) {
                AttackPlayer();
            }
        }
    }

    private void CaughtPlayer() {
        _movementModule.SetTarget(Player.instance);
        _enemyState = EnemyState.Following;
    }

    private void LostPlayer() {
        _movementModule.LostTarget();
        _enemyState = EnemyState.Idle;
    }

    private void AttackPlayer() {
        _enemyState = EnemyState.Attacking;
        _enemyAttack.Attack(Player.instance);
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

    private void SetTarget(IDamageable target) {
        _movementModule.SetTarget(target);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            IDamageable iDamageable = other.GetComponent<Player>();
            SetTarget(iDamageable);
            _enemyAttack.Attack(iDamageable);
        }
    }
    
}
