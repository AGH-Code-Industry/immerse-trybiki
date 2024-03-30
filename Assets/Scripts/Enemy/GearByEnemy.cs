using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GearByEnemy : MonoBehaviour
{
    [SerializeField] private GameObject particleHit;
    private Rigidbody2D rb;
    private float _timeToLive = 10f;

    private float _damage;
    private void Awake() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _timeToLive -= Time.deltaTime;
        if (_timeToLive < 0f) {
            Destroy(gameObject);
        }
    }

    public void ThrowGear(Vector2 targetPosition, float force, float damage) {
        _damage = damage;
        rb.AddForce(new Vector2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y).normalized * force, ForceMode2D.Impulse);
        rb.AddTorque(10);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Component damageable = null;
        if (other.TryGetComponent(typeof(IDamageable), out damageable) && !other.CompareTag("Enemy") ){
            ((IDamageable)damageable).TakeDamage(_damage);
            Instantiate(particleHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
