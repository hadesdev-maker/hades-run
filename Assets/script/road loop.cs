using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadloop : MonoBehaviour
{
    public GameObject roadsection;
    public float spawnOffset = 370f;  // Distance to spawn the new road section ahead
    public float spawnCooldown = 2f;  // Cooldown between spawns

    private bool canSpawn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canSpawn && other.gameObject.CompareTag("Player"))
        {
            // Prevent immediate spawns
            canSpawn = false;

            // Instantiate the new road section at the desired position
            GameObject newRoadSection = Instantiate(roadsection, new Vector3(0, 0, transform.position.z + spawnOffset), Quaternion.identity);

            // Get the roadmovement component of the new road section
            roadmovement newRoadMovement = newRoadSection.GetComponent<roadmovement>();

            // Ensure the new road section inherits the current speed
            if (newRoadMovement != null)
            {
                newRoadMovement.SetInitialSpeed(roadmovement.GetCurrentSpeed());
            }

            // Start the cooldown before allowing the next spawn
            StartCoroutine(SpawnCooldown());
        }
    }

    private IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }
}
