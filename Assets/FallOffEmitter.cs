using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FallOffEmitter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onFallOff;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            onFallOff.Invoke();
        }
    }
}
