using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerArrows : MonoBehaviour {
    public static PlayerArrows instance;
    [SerializeField] private GameObject _enemyArrowPrefab;
    [SerializeField] private GameObject _shopArrowPrefab;

    private void Awake() {
        instance = this;
    }

    public void SpawnEnemyArrow(Enemy enemy) {
        Instantiate(_enemyArrowPrefab, transform.position, transform.rotation, transform).GetComponent<PlayerArrow>().StartPointing(enemy.gameObject);
    }

    public void SpawnShopArrow(Shop shop)
    {
        Instantiate(_shopArrowPrefab, transform.position, transform.rotation, transform).GetComponent<PlayerArrow>().StartPointing(shop.gameObject);
    }
}
