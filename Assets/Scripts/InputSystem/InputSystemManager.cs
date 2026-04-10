using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputSystemManager : MonoBehaviour
{
    public static event UnityAction<Vector2> OnTouch;

    InputSystem inputSystem;

    void Awake()
    {
        inputSystem = new();
        inputSystem.Enable();
        inputSystem.Player.Touch.performed += OnTouchPerformed;
    }

    void OnTouchPerformed(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = context.ReadValue<Vector2>();
        OnTouch?.Invoke(touchPosition);
    }
}
