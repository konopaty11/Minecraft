using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] float maxDistance;

    public Vector2 Movement { get; private set; }
    public Vector2 Direction { get; private set; }

    RectTransform _joystick;
    Vector2 _startPosition;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        _joystick = GetComponent<RectTransform>();
        _startPosition = _joystick.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 targetPosition = _joystick.anchoredPosition + eventData.delta;

        float distance = Vector2.Distance(_startPosition, targetPosition);
        float clampedDistance = Mathf.Clamp(distance, 0f, maxDistance);
        Direction = (targetPosition - _startPosition).normalized;

        Movement = Direction * clampedDistance;
        _joystick.anchoredPosition = _startPosition + Movement;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _joystick.anchoredPosition = _startPosition;
        Movement = Vector2.zero;
    }
}
