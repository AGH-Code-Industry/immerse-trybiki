using System.Collections.Generic;
using UnityEngine;

namespace RangeAttack {
    [RequireComponent(typeof(Collider2D))]
    public class PlayerGearsManager : MonoBehaviour
    {
        public GearQueue _gearQueue;
        [SerializeField]
        private List<GameObject> initialGearList = new List<GameObject>();
        [SerializeField]
        public int maxGears = 6;
        
        private void Awake() {
            _gearQueue = GetComponent<GearQueue>();
        }

        public bool CanThrowGear() {
            return _gearQueue.HasAnyGear();
        }
    
        public void ThrowGear(Vector3 player) {
            if (_gearQueue.TryGetNextGear(out var gear)) {
                GameObject gearObject = Instantiate(gear, transform.position, Quaternion.identity);
                gearObject.GetComponent<Gear>().ThrowGear(player);
            }
        }
    
        public void PickupGear(GameObject gear) {
            _gearQueue.AddGear(gear);
            gear.SetActive(false);
        }
        
        public void ResetGearSetup() {
            _gearQueue.SetGearSetup(initialGearList);
        }
    }
}
