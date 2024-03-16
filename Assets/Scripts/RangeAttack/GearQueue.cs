using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearQueue : MonoBehaviour
{
    private Queue<GameObject> _gearQueue = new Queue<GameObject>();
    
    public void AddGear(GameObject gear) {
        _gearQueue.Enqueue(gear);
    }
    
    public bool TryGetNextGear(out GameObject gear) {
        if (HasAnyGear()) {
            gear = _gearQueue.Dequeue();
            return true;
        }
        gear = null;
        return false;
    }
    
    public void ClearGearQueue() {
        _gearQueue.Clear();
    }

    public void SetGearSetup(List<GameObject> gearSet) {
        ClearGearQueue();
        foreach (var gear in gearSet) {
            _gearQueue.Enqueue(gear);
        }
    }

    public bool HasSpaceForNextGear(int maxSize) {
        return _gearQueue.Count < maxSize;
    }

    public bool HasAnyGear() {
        return _gearQueue.Count > 0;
    }
}
