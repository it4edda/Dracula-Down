using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float panSpeed = 10f;
    public bool cameraCanMove = false;
    private void FixedUpdate()
    {
        if(!cameraCanMove) return;
        targetPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, panSpeed * 0.01f);
    }
}
