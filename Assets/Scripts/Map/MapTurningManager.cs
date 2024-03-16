using System;
using UnityEngine;

namespace Map {
    public class MapTurningManager : Observable {
        private float _actualRotationPercentage = 0;
        public float ActualRotationPercentage {
            get => _actualRotationPercentage;
            set {
                _actualRotationPercentage = value;
                InvokeAllSubscribers();
            }
        }
    }
}
