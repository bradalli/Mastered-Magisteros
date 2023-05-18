using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : Item
{
    public enum weaponTypes { Melee, Ranged, Shield}
    public weaponTypes type;
    public enum weaponEffects { None, Sharp, Blunt, Poisoned}
    public weaponEffects effect;

    bool twoHanded;

    [Header("Stats")]
    public int baseDamage;
    public int baseAttackSpeed;
}
