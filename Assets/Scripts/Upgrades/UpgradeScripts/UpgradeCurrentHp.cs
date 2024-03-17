using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCurrentHp : Upgradable
{
    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        Buy();
        playerStatistics.IncreaseHp(value);
    }
}
