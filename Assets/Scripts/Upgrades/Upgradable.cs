using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradable : MonoBehaviour
{
    protected PlayerStatistics playerStatistics;

    public void Initialize()
    {
        playerStatistics = FindAnyObjectByType<Player>().GetComponent<PlayerStatistics>();
    }

    virtual public void IncreaseStat(float value)
    {
        return;
    }
}
