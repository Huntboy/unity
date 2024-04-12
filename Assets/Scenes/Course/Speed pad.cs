using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedpad : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; // Default direction
    public float speedBoostFactor = 2f; // Default speed boost factor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Assuming golf ball has a tag "GolfBall"
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Boost the velocity of the golf ball in the specified direction
                rb.velocity += direction.normalized * speedBoostFactor;
            }
        }
    }
}

