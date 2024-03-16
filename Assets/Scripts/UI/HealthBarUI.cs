using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour {
    private Image healthBarUI;

    private void Awake() {
        healthBarUI = GetComponent<Image>();
    }

    public void SetFill(float percent) {
        healthBarUI.fillAmount = percent;
    }
    
}
