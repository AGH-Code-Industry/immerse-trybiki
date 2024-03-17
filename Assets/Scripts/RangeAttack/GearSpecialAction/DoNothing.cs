using System;
using UnityEngine;

namespace RangeAttack.GearSpecialAction {
    public class DoNothing : GearSpecialAction {
        private ParticleSystem _particleSystem;

        private void Start() {
            _particleSystem = transform.GetComponentInChildren<ParticleSystem>();
        }

        public override void Invoke() {
            _particleSystem.Play();
            return;
        }
    }
}