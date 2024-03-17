using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGear : Upgradable{  // Start is called before the first frame update
    public int number;
    
    override public void IncreaseStat(float value)
    {
        if (!CanBuy()) return;
        Buy();
        GearQueue.instance.AddGear(number);
    }
}
