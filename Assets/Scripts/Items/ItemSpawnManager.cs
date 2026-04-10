using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] ItemsConfig _config;
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] Transform _itemParent;

    public static ItemSpawnManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;
    }

    public void SpawnItem(ItemType type, Vector3 position)
    {
        GameObject itemObject = Instantiate(_itemPrefab, _itemParent);
        MeshFilter itemFilter = itemObject.GetComponent<MeshFilter>();
        itemFilter.mesh = _config.GetItemSeriazlizable(type).mesh;
        itemObject.transform.position = position;
    }
}
