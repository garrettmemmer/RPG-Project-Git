using UnityEngine;
using System.Collections;
using RPG.Movement;

public class TeleportZone : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform teleportDestination;       // Where the player will go
    public float teleportDelay = 1f;            // Time in seconds before teleport
    public GameObject teleportParticles;        // Particle prefab to spawn

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (teleportDestination != null)
            {
                StartCoroutine(TeleportWithDelay(other.transform));
            }
            else
            {
                Debug.LogError("Teleport failed: teleportDestination is NULL!");
            }
        }
    }

    private IEnumerator TeleportWithDelay(Transform player)
    {
        // Spawn particles at current location
        if (teleportParticles != null)
        {
            Instantiate(teleportParticles, player.position, Quaternion.identity);
        }
        player.GetComponent<Mover>().Cancel(); //cancell the movement command!

        // Wait before teleporting
        yield return new WaitForSeconds(teleportDelay);

        // Move player
        player.position = teleportDestination.position;
        player.rotation = teleportDestination.rotation;

        // Spawn particles at new location
        if (teleportParticles != null)
        {
            Instantiate(teleportParticles, teleportDestination.position, Quaternion.identity);
        }
    }
}
