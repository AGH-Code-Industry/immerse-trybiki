using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMovementSpeed : Upgradable
{
    override public void IncreaseStat(float value)
    {
        playerStatistics.IncreaseMovementSpeed(value);
    }
}
