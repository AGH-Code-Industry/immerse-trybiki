using System;
using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawners : MonoBehaviour {
    public static EnemySpawners instance;
    
    private EnemySpawner[] _spawners;

    [SerializeField][Range(0f, 100f)]private float _percentForFlying;

    private List<Enemy> _spawnedEnemys = new();

    [SerializeField] private int EnemyOnStart;
    [SerializeField] private float WaveMultiplayer;
    [SerializeField] private float pauseTimeBeetweenWave;
    [SerializeField] private float startDelay;
    private float enemyCount;

    private void Awake() {
        instance = this;
        _spawners = GetComponentsInChildren<EnemySpawner>();
        enemyCount = EnemyOnStart;
        StartCoroutine(StartGameDelay(startDelay));
    }

    private IEnumerator StartGameDelay(float delay) {
        yield return new WaitForSeconds(delay);
        SpawnEnemys(EnemyOnStart);
    }

    public void RemoveEnemy(Enemy enemy) {
        _spawnedEnemys.Remove(enemy);
        if (_spawnedEnemys.Count == 0) {
            EndWave();
        }
    }

    private void EndWave() {
        StartCoroutine(NextWave(pauseTimeBeetweenWave));
        MapTurningManager.intance.IncreaseTurningSpeed();
    }

    private IEnumerator NextWave(float time) {
        yield return new WaitForSeconds(time);
        StartNextWave();
    }

    private void StartNextWave() {
        enemyCount *= WaveMultiplayer;
        Debug.Log("Enemy count: " + enemyCount);
        SpawnEnemys(Mathf.FloorToInt(enemyCount));
    }

    public void SpawnEnemys(int count) {
        for (int i = 0; i < count; i++) {
            _spawnedEnemys.Add(_spawners[Random.Range(0, _spawners.Length)].SpawnEnemy(Random.Range(0f, 100f) < _percentForFlying ? EnemyType.flying : EnemyType.kamikaze));
        }
    }
    
    
}
