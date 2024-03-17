#if UNITY_EDITOR
using UnityEditor.Timeline.Actions;
#endif
using UnityEngine;

namespace RangeAttack.GearSpecialAction {
    public abstract class GearSpecialAction : MonoBehaviour {
        public abstract void Invoke();
    }
}