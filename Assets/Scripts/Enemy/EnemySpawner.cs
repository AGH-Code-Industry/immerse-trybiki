using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    flying,
    kamikaze
}

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private List<GameObject> _types;
    
    public void SpawnEnemy(EnemyType typeToSpawn) {
        Instantiate(_types[(int)typeToSpawn], transform.position, transform.rotation);
    }
}
