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

    [SerializeField] private Button _tryAgain1;
    [SerializeField] private Button _tryAgain2;

    private void Awake() {
        instance = this;
        finishGame.SetActive(false);
        losegame.SetActive(false);
        _tryAgain1.onClick.AddListener(() => GameManager.instance.ReloadScene());
        _tryAgain2.onClick.AddListener(() => GameManager.instance.ReloadScene());
    }

    public void LoseGame() {
        losegame.SetActive(true);
    }

    public void WinGame() {
        finishGame.SetActive(true);
        GameManager.instance.StopCountTime();
        timetext.text = "You finished in: " + Mathf.Floor(GameManager.instance.time) + " seconds";
    }
}
