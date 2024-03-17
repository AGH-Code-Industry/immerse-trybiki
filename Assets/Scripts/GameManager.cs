using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float time;
    private bool countTime;
    
    private void Awake() {
        time = 0f;
        instance = this;
        countTime = true;
    }

    private void Update() {
        if (countTime) {
            time += Time.deltaTime;
        }
    }

    public void StopCountTime() {
        countTime = false;
    }

    public void ReloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnPlayerDeath() {
        ReloadScene();
    }
}
