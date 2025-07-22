using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Road"))
        {
            // Destroy the game object that this script is attached to
            Destroy(gameObject);
        }
    }
}
