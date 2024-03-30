using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {
    public static GameEnd instance;
    
    public GameObject finishGame;
    public GameObject losegame;

    [SerializeField] private TextMeshProUGUI timetext;

    private void Awake() {
        instance = this;
        finishGame.SetActive(false);
        losegame.SetActive(false);
    }

    public void LoseGame() {
        TurnOffAllUI();
        losegame.SetActive(true);
    }

    public void WinGame() {
        TurnOffAllUI();
        finishGame.SetActive(true);
        GameManager.instance.StopCountTime();
        timetext.text = "You finished in: " + Mathf.Floor(GameManager.instance.time) + " seconds";
    }

    void TurnOffAllUI()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
