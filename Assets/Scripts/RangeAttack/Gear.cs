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
    private void Awake() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    public void ThrowGear(Vector3 player) {
        var actualCameraPosition = InputManager.MouseWorldPosition;
        rb.AddForce(new Vector2(actualCameraPosition.x - player.x, actualCameraPosition.y - player.y).normalized * gearSO.gearThrowForce, ForceMode2D.Impulse);
        rb.AddTorque(10);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Component damageable = null;
        if (other.TryGetComponent(typeof(IDamageable), out damageable) && !other.CompareTag("Player") ){
            ((IDamageable)damageable).TakeDamage(gearSO.gearDamage);
            gearSO.gearSpecialAction.GetComponent<GearSpecialAction>().Invoke();
        }
    }
}
