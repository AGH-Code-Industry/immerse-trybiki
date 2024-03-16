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
    [SerializeField] Image upgradeSprite;
    [SerializeField] Button upgradeButton;

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
        upgradePrice.text = upgradeSO.upgradePrice.ToString();
        upgradeButton.onClick.AddListener(() => upgradeSO.upgradable.GetComponent<Upgradable>().IncreaseStat(upgradeSO.upgradeValue));
    }
}
