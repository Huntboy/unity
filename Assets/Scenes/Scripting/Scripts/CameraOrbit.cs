using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float height = 4f;
    public float distance = 8f;
    public float rotationSpeed = 3f;
    public float verticalRotation = 20f;

    private float currentRotationSpeed = 0f;

    void Update()
    {
        if (target == null)
            return;

        float rotationInput = Input.GetAxis("Horizontal");
        currentRotationSpeed = rotationInput * rotationSpeed;
        UpdateCameraPosition();

    }

    void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(verticalRotation, transform.eulerAngles.y + currentRotationSpeed, 0);
        Vector3 newPosition = target.position - rotation * Vector3.forward * distance;
        newPosition.y = target.position.y + height;

        transform.position = newPosition;
        transform.LookAt(target.position + Vector3.up * height);
    }
}
