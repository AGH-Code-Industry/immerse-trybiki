using System;
using UnityEngine;

namespace Map {
    public class MapTurningManager : Observable {
        [SerializeField] private float turnStep = 0.01f;

        private float _actualRotationPercentage = 0;
        private float _desiredRotationPercentage = 0;
        public float ActualRotationPercentage {
            get => _actualRotationPercentage;
            set {
                if (value < 0) value = 0;
                if (value > 1) value = 1;
                _actualRotationPercentage = value;
                InvokeAllSubscribers();
            }
        }

        public float DesiredRotationPercentage
        {
            get => _desiredRotationPercentage;
            set { _desiredRotationPercentage = value;}
        }

        private void Update()
        {
            if (Mathf.Abs(ActualRotationPercentage - _desiredRotationPercentage) < 2 * turnStep) return;
            if (ActualRotationPercentage > _desiredRotationPercentage)
            {
                ActualRotationPercentage -= turnStep * Time.deltaTime;
            } else
            {
                ActualRotationPercentage += turnStep * Time.deltaTime;
            }
            
        }
    }
}
