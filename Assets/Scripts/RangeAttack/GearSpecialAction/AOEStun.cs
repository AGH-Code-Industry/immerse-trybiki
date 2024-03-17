using System.Collections;
using System.Collections.Generic;
using RangeAttack.GearSpecialAction;
using UnityEngine;

public class AOEStun : GearSpecialAction
{
    [SerializeField]
    private float radius = 1f;

    [SerializeField] private float stunTime;
    [SerializeField]
    private GearSO gearSO;
    private ParticleSystem _particleSystem;

    private void Start() {
        _particleSystem = transform.GetComponentInChildren<ParticleSystem>();
    }

    public override void Invoke() {
        foreach (var collider2D in Physics2D.OverlapCircleAll(transform.position, radius)) {
            if (collider2D.TryGetComponent(typeof(IDamageable), out var damageable) && !collider2D.CompareTag("Player") ) {
                ((IDamageable)damageable).TakeDamage(gearSO.gearDamage);
                damageable.GetComponent<IStunable>().StunFor(stunTime);
            }
        }
    }
}
