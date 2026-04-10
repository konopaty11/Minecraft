using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] EntityType _entityType;
    [SerializeField] float _health;
    [SerializeField] EntityDropConfig _dropConfig;

    public float CurrentHealth { get; private set; }

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        CurrentHealth = _health;
    }

    public void SubtractHealth(float delta)
    {
        CurrentHealth -= delta;
        Debug.Log($"health {CurrentHealth}");
        if (CurrentHealth < 0)
            Die();
    }

    public void Die()
    {
        List<ItemType> items = _dropConfig.GetDrop(_entityType);
        for (int i = 0; i < items.Count; i++)
        {
            ItemSpawnManager.Instance.SpawnItem(items[i], transform.position + 0.1f * i * Vector3.up);
        }

        Destroy(gameObject);
    }
}
