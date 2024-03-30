using System;
using UnityEngine;

namespace Map {
    public class MapTurningManager : Observable {
        public static MapTurningManager intance;
        [SerializeField] private float turnStep = 0.01f;
        [SerializeField] private float timeMultiplayer = 0.01f;

        private float _actualRotationPercentage = 0;
        private float _desiredRotationPercentage = 0;

        private void Awake() {
            intance = this;
        }

        public void IncreaseTurningSpeed() {
            turnStep += timeMultiplayer;
        }

        public float ActualRotationPercentage {
            get => _actualRotationPercentage % 1;
            set {
                if (value < 0) value = 0;
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
            ActualRotationPercentage += turnStep * Time.deltaTime;
        }
    }
}
