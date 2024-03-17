using System;
using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using UnityEngine.Events;

public class MachineManager : MonoBehaviour {
    public static MachineManager instance;
    [SerializeField]
    private int currentGears;
    public int CurrentGears {
        get => currentGears;
        set {
            currentGears = value;
            if (currentGears <= 0) {
                zeroGarsReached.Invoke();
            }
            if (currentGears >= maxGears) {
                garsReached.Invoke();
            }
            garsChanged.Invoke();
            UpdateMapTurning();
        }
    }
    [SerializeField]
    private int maxGears;
    
    public UnityEvent zeroGarsReached;
    public UnityEvent garsChanged;
    public UnityEvent garsReached;

    private MapTurningManager mapTurningManager;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        mapTurningManager = FindObjectOfType<MapTurningManager>();
    }

    public void AddGears(int number) {
        CurrentGears += number;
    } 
    
    public void SubtractGears(int number) {
        CurrentGears -= number;
    }

    private void UpdateMapTurning() {
        mapTurningManager.DesiredRotationPercentage = (float)currentGears / maxGears;
    }
}
