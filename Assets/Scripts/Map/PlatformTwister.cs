using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;

public class PlatformTwister : MonoBehaviour, ISubscriber
{
    private MapTurningManager mapTurningManager;
    [SerializeField]
    private RotateDirection rotateDirection;

    private float maxAngleRotation;
    void Start()
    {
        mapTurningManager = FindObjectOfType<MapTurningManager>();
        mapTurningManager.Subscribe(this);
        maxAngleRotation = transform.parent.GetComponent<GearTwister>().MaxAngleRotation;
    }
    public void Invoke() {
        UpdateRotate();
    }
    
    private void UpdateRotate() {
        transform.rotation = transform.parent.rotation * Quaternion.Lerp(Quaternion.Euler(0,0,0), Quaternion.Euler(0,0,rotateDirection == RotateDirection.Left ? -maxAngleRotation : maxAngleRotation), mapTurningManager.ActualRotationPercentage);
        // transform.rotation = Quaternion
        // transform.rotation 
        // transform.rotation.eulerAngles = new Vector3(0, 0, 0);

    }
}
