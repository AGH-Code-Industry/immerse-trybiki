using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollect : MonoBehaviour {
    private PlayerStatistics _playerStatistics;

    private void Awake() {
        _playerStatistics = GetComponentInParent<PlayerStatistics>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("GearMoney")) {
            _playerStatistics.CurrentMoney++;
            Destroy(other.gameObject);
        }
    }
}
