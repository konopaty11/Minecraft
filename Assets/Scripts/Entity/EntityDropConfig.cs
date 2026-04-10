using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityDropConfig", menuName = "Scriptable Object/EntityDropConfig")]
public class EntityDropConfig : ScriptableObject
{
    public List<EntityDropSerializable> entityDrops;

    public List<ItemType> GetDrop(EntityType type)
    {
        foreach (EntityDropSerializable dropSerializable in entityDrops)
        {
            if (dropSerializable.type == type)
                return dropSerializable.items;
        }

        return null;
    }
}

[Serializable]
public class EntityDropSerializable
{
    public EntityType type;
    public List<ItemType> items;
}