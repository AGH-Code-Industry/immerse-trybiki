using System;
using System.Collections;
using System.Collections.Generic;
using RangeAttack.GearSpecialAction;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Gear : MonoBehaviour
{
    [SerializeField]
    private GearSO gearSO;
    private Rigidbody2D rb;
    
    private float _timeToLive = 10f;

    private void Awake() {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        _timeToLive -= Time.deltaTime;
        if (_timeToLive < 0f) {
            Destroy(gameObject);
        }
    }

    public void ThrowGear(Vector3 player) {
        var actualCameraPosition = InputManager.MouseWorldPosition;
        rb.AddForce(new Vector2(actualCameraPosition.x - player.x, actualCameraPosition.y - player.y).normalized * gearSO.gearThrowForce, ForceMode2D.Impulse);
        rb.AddTorque(10);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        Component damageable = null;
        if (other.TryGetComponent(typeof(IDamageable), out damageable) && !other.CompareTag("Player") ){
            Debug.Log("Dupa");
            ((IDamageable)damageable).TakeDamage(gearSO.gearDamage);
            gearSO.gearSpecialAction.GetComponent<GearSpecialAction>().Invoke();
        }
    }
}
