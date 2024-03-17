using System;
using System.Collections;
using System.Collections.Generic;
using RangeAttack;
using UnityEngine;

public class GearCollect : MonoBehaviour {
    private PlayerStatistics _playerStatistics;
    private PlayerGearsManager _playerGearsManager;

    private void Awake() {
        _playerStatistics = GetComponentInParent<PlayerStatistics>();
        _playerGearsManager = GetComponentInParent<PlayerGearsManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("GearMoney")) {
            _playerStatistics.CurrentMoney++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GearPickUp") && _playerGearsManager._gearQueue.HasSpaceForNextGear(_playerGearsManager.maxGears)) {
            _playerGearsManager.PickupGear(other.gameObject);
        }
    }
}
