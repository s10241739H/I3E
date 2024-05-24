using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTrigger : MonoBehaviour
{
private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.SetInitialTriggerActivated(true);
                Debug.Log("Initial trigger activated");
            }

            Destroy(gameObject); // Destroys aftert player walks
        }
    }
}
