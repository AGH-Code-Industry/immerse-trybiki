using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Gear")]
public class GearSO : ScriptableObject
{
    public string gearName;
    public int gearDamage;
    public float gearThrowForce;
    public float gearLifeTime;
    public float gearKnockback;
    public GameObject gearSpecialAction;
    public GearType GearType;
}
