using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMovementSpeed : Upgradable
{
    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        Buy();
        playerStatistics.IncreaseMovementSpeed(value);
    }
}
