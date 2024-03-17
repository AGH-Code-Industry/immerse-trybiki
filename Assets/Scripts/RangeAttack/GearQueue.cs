using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearQueue : MonoBehaviour {
    public static GearQueue instance;
    private UiGearQueueDisplay uiGearQueueDisplay;
    private Queue<GameObject> _gearQueue = new Queue<GameObject>();
    
    public List<GameObject> _gearsWithTypes = new();

    private void Awake() {
        instance = this;
        uiGearQueueDisplay = FindObjectOfType<UiGearQueueDisplay>();
    }

    public void AddGear(GameObject gear) {
        _gearQueue.Enqueue(_gearsWithTypes[(int)gear.GetComponent<Gear>().gearSO.GearType]);
        UpdateUiGears();
    }

    public void AddGear(int number) {
        _gearQueue.Enqueue(_gearsWithTypes[number]);
        UpdateUiGears();
    }
    
    public bool TryGetNextGear(out GameObject gear) {
        if (HasAnyGear()) {
            gear = _gearQueue.Dequeue();
            UpdateUiGears();
            return true;
        }
        gear = null;
        return false;
    }
    
    public void ClearGearQueue() {
        _gearQueue.Clear();
        UpdateUiGears();
    }

    public void SetGearSetup(List<GameObject> gearSet) {
        ClearGearQueue();
        foreach (var gear in gearSet) {
            _gearQueue.Enqueue(gear);
        }
        UpdateUiGears();
    }

    public bool HasSpaceForNextGear(int maxSize) {
        return _gearQueue.Count < maxSize;
    }

    public bool HasAnyGear() {
        return _gearQueue.Count > 0;
    }
    
    private void UpdateUiGears() {
        var gears = _gearQueue.ToArray();
        List<GameObject> gearToDisplay = new List<GameObject>();
        for (int i = 0; i < 3; i++) {
            if(i < gears.Length) {
                gearToDisplay.Add(gears[i]);
            }
            else {
                break;
            }
        }
        uiGearQueueDisplay.SetGearImages(gearToDisplay);
    }
}
