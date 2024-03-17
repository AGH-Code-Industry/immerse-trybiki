using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawners : MonoBehaviour {
    public static EnemySpawners instance;
    
    private EnemySpawner[] _spawners;

    [SerializeField][Range(0f, 100f)]private float _percentForFlying;

    private void Awake() {
        instance = this;
        _spawners = GetComponentsInChildren<EnemySpawner>();
    }

    public void SpawnEnemys(int count) {
        for (int i = 0; i <= count; i++) {
            _spawners[Random.Range(0, _spawners.Length)].SpawnEnemy(Random.Range(0f, 100f) < _percentForFlying ? EnemyType.flying : EnemyType.kamikaze);
        }
    }
    
    
}
