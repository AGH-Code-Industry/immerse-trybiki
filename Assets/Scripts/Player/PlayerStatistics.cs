using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField] private float maxHp = 10f;
    [SerializeField] private float currHp;
    [SerializeField] private int numberOfJumps = 1;
    [SerializeField] private float meleeDmg;
    [SerializeField] private float weaponDmg;
    [SerializeField] private float meleeAttackCooldown = 1f;
    [SerializeField] private float rangeAttackCooldown = 1f;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float jumpForce = 2f;

    public float MeleeAttackCooldown => meleeAttackCooldown;
    public float RangeAttackCooldown => rangeAttackCooldown;
    public float MovementSpeed => movementSpeed;
    public float JumpForce => jumpForce;
    public float MeleeDMG => meleeDmg;
    public float WeaponDMG => weaponDmg;
    public int NumberOfJumps => numberOfJumps;


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

    public void IncreaseMovementSpeed(float value)
    {
        movementSpeed += value;
    }

    public void IncreaseJumpForce(float value)
    {
        jumpForce += value;
    }

    public void IncreaseNumberOfJumps(int value)
    {
        numberOfJumps += value;
    }

    public void IncreaseMeleeWeaponDamage(float value)
    {
        meleeDmg += value;
    }

    public void IncreaseMaxPlayerHp(int value)
    {
        maxHp = value;
    }

    public void DecreaseMeleeCooldown(float value)
    {
        meleeAttackCooldown -= value;
    }

    public void DecreaseRangeCooldown(float value)
    {
        rangeAttackCooldown -= value;
    }
}
