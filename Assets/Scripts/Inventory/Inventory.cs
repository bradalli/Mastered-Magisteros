using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void AddItemToContainer(Item item, int quantity)
    {
        if (itemContainer.ContainsKey(item))
        {
            itemContainer[item] = itemContainer[item] + quantity;
        }

        else
        {
            itemContainer.Add(item, quantity);
        }
    }

    public void RemoveItemFromContainer(Item item, int quantity)
    {
        if (itemContainer.ContainsKey(item) && quantity < itemContainer[item])
        {
            itemContainer[item] = itemContainer[item] - quantity;
        }

        else
        {
            itemContainer.Remove(item);
        }
    }

    public void EquipItem(Equipment equipItem)
    {
        if (!equipmentContainer.ContainsValue(equipItem))
        {
            equipmentContainer[equipItem.targetSlot] = equipItem;
        }
    }

    public void UnequipItem(Equipment equipItem)
    {
        if (equipmentContainer.ContainsValue(equipItem))
        {
            equipmentContainer[equipItem.targetSlot] = equipItem;
        }
    }
}
