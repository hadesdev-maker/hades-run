using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player character

    void Update()
    {
        // Set the camera's position and rotation to match the player character
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
