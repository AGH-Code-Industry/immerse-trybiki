using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    Idle,
    Following,
    Attacking,
    Aiming
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
    public float AttackCooldownMax => _attackCooldownMax;
    
    private float _hp;
    private float _attackDamage;
    private float _timeMultiplayer;
    private AttackType _attackType;
    private float _speed;
    private float _caughtDistance;
    private float _attackDistance;
    private float _attackCooldownMax;
    private float _aimingDistance;

    private float _attackCooldown;

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
        _attackCooldownMax = _enemySO.cooldown;
        _aimingDistance = _enemySO.aimingDistance;
        _attackCooldown = 0f;
    }

    private void Start() {
        CaughtPlayer();
    }

    private void Update() {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.instance.transform.position);
        switch (_enemyState) {
            case EnemyState.Idle:
                if (distanceToPlayer < _caughtDistance) {
                    CaughtPlayer();        
                }
                break;
            case EnemyState.Following:
                Debug.Log(distanceToPlayer);
                if (distanceToPlayer > _caughtDistance) {
                    LostPlayer();
                }
                if (distanceToPlayer < _attackDistance) {
                    AimingPlayer();
                }
                break;
            case EnemyState.Aiming:
                if (distanceToPlayer > _attackDistance + _aimingDistance) {
                    CaughtPlayer();
                    break;
                }
                _attackCooldown -= Time.deltaTime;
                if (_attackCooldown <= 0f) {
                    AttackPlayer();
                }
                break;
            case EnemyState.Attacking:
                AimingPlayer();
                break;
        }
    }

    private void CaughtPlayer() {
        _movementModule.SetTarget(Player.instance);
        _enemyState = EnemyState.Following;
        _target = Player.instance;
        _movementModule.StopAiming();
    }

    private void LostPlayer() {
        _movementModule.LostTarget();
        _enemyState = EnemyState.Idle;
        _target = null;
    }

    private void AttackPlayer() {
        _enemyState = EnemyState.Attacking;
        _enemyAttack.SetTarget(Player.instance);
        _enemyAttack.Attack(Player.instance);
        _attackCooldown = _attackCooldownMax;
    }

    private void AimingPlayer() {
        _enemyState = EnemyState.Aiming;
        _movementModule.StartAiming(); 
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
