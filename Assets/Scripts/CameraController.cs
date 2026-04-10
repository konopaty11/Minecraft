using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 moveOffset;
    [SerializeField] Vector3 lookOffset;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position + moveOffset, 0.5f);   
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target.position - transform.position + lookOffset), 0.5f);   
    }
}
