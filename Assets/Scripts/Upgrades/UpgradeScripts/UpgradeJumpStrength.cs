using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeJumpStrength : Upgradable
{
    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        Buy();
        playerStatistics.IncreaseJumpForce(value);
    }
}
