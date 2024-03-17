using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;

public class GearTwister : MonoBehaviour, ISubscriber
{
    private MapTurningManager mapTurningManager;
    [SerializeField]
    private RotateDirection rotateDirection;
    [SerializeField]
    private float maxAngleRotation;
    public float MaxAngleRotation => maxAngleRotation;
    void Start()
    {
        mapTurningManager = FindObjectOfType<MapTurningManager>();
        mapTurningManager.Subscribe(this);
    }

    public void Invoke() {
        UpdateRotate();
        Debug.Log("try to rotate");
    }
    
    
    
    private void UpdateRotate() {
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0,0,0), Quaternion.Euler(0,0,rotateDirection == RotateDirection.Left ? -maxAngleRotation : maxAngleRotation), mapTurningManager.ActualRotationPercentage);
    }
}
