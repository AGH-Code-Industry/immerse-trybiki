using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {
    Kamikaze,
    Weapon
}

[CreateAssetMenu(menuName = "Enemy")]
public class EnemySO : ScriptableObject {
    public string enemyName;
    public int hp;
    public AttackType attackType;
    public int attackDamage;
    public float timeMultiplayer;
    public float speed;
    public float caughtDistance;
    public float attackDistance;

}
