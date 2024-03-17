using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProgressManager : MonoBehaviour
{
    [SerializeField]
    private float leftLimit;

    [SerializeField]
    private float rightLimit;
    
    [SerializeField]
    private float currentProgress = 0;
    
    public float CurrentProgress {
        get => currentProgress;
        set {
            currentProgress = value;
            ActualizeProgress();
        }
    }
    
    private RectTransform _rectTransform;

    private void Awake() {
        _rectTransform = transform.GetComponent<RectTransform>();
        
    }

    private void Start() {
        ActualizeProgress();
    }

    private void ActualizeProgress() {
        Debug.Log("Actualize Result" + leftLimit + ((rightLimit - leftLimit) * currentProgress));
        _rectTransform.sizeDelta = new Vector2 (leftLimit + ((rightLimit - leftLimit) * currentProgress), 37);
    }
}
