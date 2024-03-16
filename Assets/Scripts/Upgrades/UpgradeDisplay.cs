using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI upgradeDescription;
    [SerializeField] TextMeshProUGUI upgradePrice;
    [SerializeField] TextMeshProUGUI upgradeLevel;
    [SerializeField] Image upgradeSprite;
    [SerializeField] Button upgradeButton;

    private int level = 0;
    private UpgradeSO upgradeSO;

    public void SetUpgradeSO(UpgradeSO upgradeSO)
    {
        this.upgradeSO = upgradeSO;
    }

    public void DisplayUpgradeStats()
    {
        upgradeName.text = upgradeSO.upgradeName;
        upgradeDescription.text = upgradeSO.upgradeDescription;
        upgradeSprite.sprite = upgradeSO.upgradeUI;
        upgradePrice.text = GetUpgradePrice().ToString();
        upgradeButton.onClick.AddListener(() => upgradeSO.upgradable.GetComponent<Upgradable>().IncreaseStat(upgradeSO.upgradeValue));
        upgradeLevel.text = "Level: " + level.ToString();
    }

    public void LevelUp()
    {
        level += 1;
    }

    public int GetUpgradePrice()
    {
        return upgradeSO.upgradePrice + level * upgradeSO.nextUpgradeIncreaseCost;
    }

    public UpgradeSO GetUpgradeSO()
    {
        return upgradeSO;
    }
}
