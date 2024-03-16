using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMeleeWeaponDamage : Upgradable
{
    override public void IncreaseStat(float value)
    {
        playerStatistics.IncreaseMeleeWeaponDamage(value);
    }
}
