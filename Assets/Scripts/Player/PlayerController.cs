using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject pickupButton;
    [SerializeField] float speed;
    [SerializeField] JoystickController joystick;

    Rigidbody _rg;

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

    void OnTriggerStay(Collider other)
    {
        pickupButton.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        pickupButton.SetActive(false);
    }
}
