using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsConfig", menuName = "Scriptable Objects/ItemsConfig")]
public class ItemsConfig : ScriptableObject
{
    public List<ItemSerializable> items;

    public ItemSerializable GetItemSeriazlizable(ItemType type)
    {
        foreach (ItemSerializable item in items)
        {
            if (item.type == type)
                return item;
        }

        throw new ArgumentException($"Item serializable {type} do not exist");
    }
}

[Serializable]
public class ItemSerializable
{
    public ItemType type;
    public Mesh mesh;
}