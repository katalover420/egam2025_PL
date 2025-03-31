using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCameraShake : MonoBehaviour
{
    public float shakeAmount = 0f;  // Set a default shake amount
    public float shakeDuration = 0.2f;  // Duration of the shake

    private Vector3 initialPos;
    private float shakeTimer = 0f;  // Timer to track shake duration

    void Awake()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Shake the camera while the timer is running
            transform.position = initialPos + Random.insideUnitSphere * shakeAmount;
            shakeTimer -= Time.deltaTime;  // Reduce timer by elapsed time
        }
        else
        {
            // Stop shaking and reset the position
            transform.position = initialPos;
        }
    }

    // Call this function to start the shake
    public void StartShake()
    {
        shakeTimer = shakeDuration;
    }
}
