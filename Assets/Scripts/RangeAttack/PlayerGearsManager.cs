using System.Collections.Generic;
using UnityEngine;

namespace RangeAttack {
    [RequireComponent(typeof(Collider2D))]
    public class PlayerGearsManager : MonoBehaviour
    {
        private GearQueue _gearQueue;
        [SerializeField]
        private List<GameObject> initialGearList = new List<GameObject>();
        [SerializeField]
        private int maxGears = 6;

        private void Start() {
            _gearQueue = GetComponent<GearQueue>();
        }

        public bool CanThrowGear() {
            return _gearQueue.HasAnyGear();
        }
    
        public void ThrowGear() {
            if (_gearQueue.TryGetNextGear(out var gear)) {
                GameObject gearObject = Instantiate(gear, transform.position, Quaternion.identity);
                gearObject.GetComponent<Gear>().ThrowGear();
            }
        }
    
        public void PickupGear(GameObject gear) {
            _gearQueue.AddGear(gear);
            gear.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("GearPickUp") && _gearQueue.HasSpaceForNextGear(maxGears)) {
                PickupGear(other.gameObject);
            }
        }
        
        public void ResetGearSetup() {
            _gearQueue.SetGearSetup(initialGearList);
        }
    }
}
