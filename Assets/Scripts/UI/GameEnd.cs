using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {
    public GameObject finishGame;
    public GameObject losegame;

    [SerializeField] private TextMeshProUGUI timetext;

    [SerializeField] private Button _tryAgain1;
    [SerializeField] private Button _tryAgain2;

    private void Awake() {
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
        timetext.text = "You finished in: " + GameManager.instance.time + " seconds";
    }
}
