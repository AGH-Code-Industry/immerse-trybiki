using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

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
    [SerializeField] private int currentMoney = 2;
    [SerializeField] private HealthBarUI hpBar;

    [SerializeField] private TextMeshProUGUI moneyText;

    public int CurrentMoney {
        get => currentMoney;
        set {
            moneyText.text = value.ToString();
            currentMoney = value;
        }
    }
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
        hpBar.SetFill(currHp/maxHp);
        moneyText.text = currentMoney.ToString();
    }

    public void TakeDamage(float amount)
    {
        currHp -= amount;
        hpBar.SetFill(currHp/maxHp);
        if (currHp <= 0)
        {
            // todo: umieranie
            GameEnd.instance.LoseGame();
            GetComponent<Player>().onPlayerDead?.Invoke();
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
