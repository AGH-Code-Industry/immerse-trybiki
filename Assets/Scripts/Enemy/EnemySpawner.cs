using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    flying,
    kamikaze
}

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private List<GameObject> _types = new();
    
    public Enemy SpawnEnemy(EnemyType typeToSpawn) {
        return Instantiate(_types[(int)typeToSpawn], transform.position, transform.rotation).GetComponent<Enemy>();
    }
}
