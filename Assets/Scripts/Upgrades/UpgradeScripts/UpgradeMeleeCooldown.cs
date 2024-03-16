using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMeleeCooldown : Upgradable
{
    override public void IncreaseStat(float value)
    {
        playerStatistics.DecreaseMeleeCooldown(value);
    }
}
