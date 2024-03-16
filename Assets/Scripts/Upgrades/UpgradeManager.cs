using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject upgradeGO;

    List<UpgradeSO> upgrades = new List<UpgradeSO>();

    private void Awake()
    {
        Object[] objects = Resources.LoadAll("Upgrades", typeof(UpgradeSO));
        for (int i = 0; i < objects.Length; i++)
        {
            upgrades.Add(objects[i] as UpgradeSO);
        }
    }

    private void Start()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (UpgradeSO up in upgrades)
        {
            GameObject go = Instantiate(upgradeGO, content);
            up.upgradable.GetComponent<Upgradable>().Initialize();
            go.GetComponent<UpgradeDisplay>().SetUpgradeSO(up);
            go.GetComponent<UpgradeDisplay>().DisplayUpgradeStats();
        }
    }
}
