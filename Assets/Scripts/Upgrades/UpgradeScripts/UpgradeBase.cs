using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBase : Upgradable {

    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        Buy();
        MachineManager.instance.AddGears(Mathf.FloorToInt(value));
    }
}
