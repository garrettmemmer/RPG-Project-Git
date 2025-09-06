using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform teleportDestination; // Where to send the player

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the player
        if (other.CompareTag("Player"))
        {
            if (teleportDestination != null)
            {
                other.transform.position = teleportDestination.position;
                other.transform.rotation = teleportDestination.rotation; // optional
            }
            else
            {
                Debug.LogWarning("Teleport destination not set!");
            }
        }
    }
}
