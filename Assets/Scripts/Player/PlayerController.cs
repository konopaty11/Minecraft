using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject pickupButton;
    [SerializeField] float speed;
    [SerializeField] JoystickController joystick;
    [SerializeField] float damage;

    string _pickupTag = "PickableUp";
    string _attackTag = "Attackable";
    List<EntityController> _attackable = new();
    List<Item> _pickableup = new();
    Rigidbody _rg;

    void OnEnable()
    {
        InputSystemManager.OnTouch += OnTouch;
    }

    void OnDisable()
    {
        InputSystemManager.OnTouch -= OnTouch;
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        _rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveHandle();
    }

    void MoveHandle()
    {
        Vector3 position = _rg.position + new Vector3(joystick.Movement.x, 0f, joystick.Movement.y) * speed;
        _rg.MovePosition(position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_attackTag))
        {
            Debug.Log("sdf");
            _attackable.Add(other.GetComponent<EntityController>());
        }
        else if (other.CompareTag(_pickupTag))
        {
            _pickableup.Add(other.GetComponent<Item>());
            pickupButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_attackTag))
        {
            _attackable.Remove(other.GetComponent<EntityController>());
        }
        else if (other.CompareTag(_pickupTag))
        {
            _pickableup.Remove(other.GetComponent<Item>());
            if (_pickableup.Count == 0) 
                pickupButton.SetActive(true);
        }
    }

    void OnTouch(Vector2 screenPosition)
    {
        if (screenPosition.x > Screen.width / 2)
            Attack();
    }

    void Attack()
    {
        foreach (EntityController entity in _attackable)
        {
            if (entity.gameObject)
            {
                Debug.Log($"damage {damage}");
                entity.SubtractHealth(damage);
            }
        }
    }
}
