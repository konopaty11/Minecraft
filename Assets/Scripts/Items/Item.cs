using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemsConfig itemsConfig;

    public ItemType Type { get; private set; }

    public void SetItemType(ItemType type)
    {
        Type = type;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = itemsConfig.GetItemSeriazlizable(Type).mesh;
    }
}
