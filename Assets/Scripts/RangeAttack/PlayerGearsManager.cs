using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerGearsManager : MonoBehaviour
{
    private GearQueue _gearQueue;

    public bool CanThrowGear() {
        return _gearQueue.HasAnyGear();
    }
    
    public void ThrowGear() {
        if (_gearQueue.TryGetNextGear(out var gear)) {
            gear.transform.position = transform.position;
            gear.SetActive(true);
            gear.GetComponent<Gear>().ThrowGear();
        }
    }
    
    public void PickupGear(GameObject gear) {
        _gearQueue.AddGear(gear);
        gear.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Gear")) {
            PickupGear(other.gameObject);
        }
    }
}
