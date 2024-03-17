using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class UpgradeSO : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeUI;
    public int upgradePrice;
    public int nextUpgradeIncreaseCost;
    public GameObject upgradable;
    public float upgradeValue;
}
