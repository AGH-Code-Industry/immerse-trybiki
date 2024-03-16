using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMaxPlayerHp : Upgradable
{
    override public void IncreaseStat(float value)
    {
        playerStatistics.IncreaseMaxPlayerHp((int)value);
    }
}
