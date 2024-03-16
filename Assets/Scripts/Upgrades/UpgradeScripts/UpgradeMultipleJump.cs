using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMultipleJump : Upgradable
{
    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        playerStatistics.IncreaseNumberOfJumps((int)value);
    }
}
