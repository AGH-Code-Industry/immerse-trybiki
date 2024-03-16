using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Upgradable : MonoBehaviour
{
    protected PlayerStatistics playerStatistics;
    protected UpgradeDisplay upgradeDisplay;

    public void Initialize()
    {
        playerStatistics = FindAnyObjectByType<Player>().GetComponent<PlayerStatistics>();
    }

    virtual public void IncreaseStat(float value)
    {
        return;
    }

    public bool CanBuy()
    {
        if (playerStatistics.CurrentMoney <= upgradeDisplay.GetUpgradePrice()) return true;
        return false;
    }

    public void Buy()
    {
        //todo: subtract player money
    }
}
