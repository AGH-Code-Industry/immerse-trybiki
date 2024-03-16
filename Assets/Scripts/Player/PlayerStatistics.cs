using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField] private float maxHp = 10f;
    [SerializeField] private float currHp;
    [SerializeField] private int numberOfJumps = 1;
    [SerializeField] private int meleeDmg;
    [SerializeField] private int weaponDmg;
    [SerializeField] private float meleeAttackCooldown {get; }
    [SerializeField] private float rangeAttackCooldown = 1f;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float jumpForce = 2f;

    private void Start()
    {
        currHp = maxHp;
    }

    public void TakeDamage(float amount)
    {
        currHp -= amount;
        if (currHp <= 0)
        {
            // todo: umieranie
        }
    }

    public int GetNumberOfJumps() { return numberOfJumps; }
}
