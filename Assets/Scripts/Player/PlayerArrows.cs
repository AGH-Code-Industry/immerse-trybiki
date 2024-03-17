using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrows : MonoBehaviour {
    public static PlayerArrows instance;
    [SerializeField] private GameObject _arrowPrefab;

    private void Awake() {
        instance = this;
    }

    public void SpawnArrow(Enemy enemy) {
        Instantiate(_arrowPrefab, transform.position, transform.rotation, transform).GetComponent<PlayerArrow>().StartPointing(enemy);
    }
}
