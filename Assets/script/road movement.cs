using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadmovement : MonoBehaviour
{
    public float initialSpeed = 8f;  // Initial speed
    public float speedIncreaseRate = 0.1f;  // Rate of speed increase per second

    public static float currentSpeed = 0f;  // Current speed (shared across all instances)

    void Start()
    {
        // Initialize the current speed if it's the first road section
        if (currentSpeed == 0)
        {
            currentSpeed = initialSpeed;
        }
    }

    void Update()
    {
        // Move the platform
        transform.position += new Vector3(0, 0, -currentSpeed) * Time.deltaTime;

        // Increase the speed gradually over time
        currentSpeed += speedIncreaseRate * Time.deltaTime;
    }

    public void SetInitialSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public static float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public static void ResetSpeed()
    {
        currentSpeed = 0f;  // Reset the speed
    }
}
