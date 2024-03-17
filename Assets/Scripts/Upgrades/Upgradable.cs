using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Upgradable : MonoBehaviour
{
    protected PlayerStatistics playerStatistics;
    protected UpgradeDisplay upgradeDisplay;

    public void Initialize(UpgradeDisplay ud)
    {
        playerStatistics = FindAnyObjectByType<Player>().GetComponent<PlayerStatistics>();
        upgradeDisplay = ud;
    }

    virtual public void IncreaseStat(float value)
    {
        return;
    }

    public bool CanBuy()
    {
        if (playerStatistics.CurrentMoney <= upgradeDisplay.GetUpgradePrice()) return false;
        return true;
    }

    public void Buy()
    {
        playerStatistics.CurrentMoney -= upgradeDisplay.GetUpgradePrice();
        upgradeDisplay.LevelUp();
        upgradeDisplay.DisplayUpgradeStats();
    }
}
