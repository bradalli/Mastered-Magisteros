using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Items/Equipment", order = 1)]
public class Equipment : Item
{
    public Inventory.equipmentSlots targetSlot;

    [Header("Stat Modifiers")]
    public int modHealth;
    public int modArmour;
    public int modStamina;
    public int modSpeed;
    public int modDamage;
}
