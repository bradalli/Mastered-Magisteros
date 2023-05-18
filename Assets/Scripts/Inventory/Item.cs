using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
public class Item : ScriptableObject
{
    public new string name;
    public Guid id;
    public Sprite thumbnail;
    public UnityEngine.Object prefab;
    public int value = 0;
    public int weight = 1;
    public int maxStackNum = 1;
}
