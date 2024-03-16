using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRangeCooldown : Upgradable
{
    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        playerStatistics.DecreaseRangeCooldown(value);
    }
}
