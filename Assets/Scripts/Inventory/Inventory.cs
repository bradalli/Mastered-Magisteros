using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // item - the item reference, int - how many are held
    public Dictionary<Item, int> itemContainer;

    public enum equipmentSlots { Head, Neck, Torso, Waist, Wrists, Hands, Legs, Feet }
    public Dictionary<equipmentSlots, Equipment> equipmentContainer;

    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    private void Awake()
    {
        #region equipment container declaration
        equipmentContainer.Add(equipmentSlots.Head, null);
        equipmentContainer.Add(equipmentSlots.Neck, null);
        equipmentContainer.Add(equipmentSlots.Torso, null);
        equipmentContainer.Add(equipmentSlots.Waist, null);
        equipmentContainer.Add(equipmentSlots.Wrists, null);
        equipmentContainer.Add(equipmentSlots.Hands, null);
        equipmentContainer.Add(equipmentSlots.Legs, null);
        equipmentContainer.Add(equipmentSlots.Feet, null);
        #endregion
    }
}
