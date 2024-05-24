using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Door : MonoBehaviour
{
    // Flags if the door is open
    bool opened = false;

    // The duration the door remains open before closing
    public float openDuration = 3.0f;
    public TextMeshProUGUI warningMessage; // Reference to the warning message UI
    public float messageDisplayTime = 2.0f; // Time to display the message

    private void OnTriggerEnter(Collider other)
    {

        // Check if object entering the trigger is "Player" tag
        if (other.gameObject.CompareTag("Player") && !opened)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                 if (player.GetCurrentScore() >= 25)
                {
                    // If it's the player and the score is greater than 25, open the door
                    OpenDoor();

                    // Start the coroutine to close the door after the specified duration
                    StartCoroutine(CloseDoorAfterDelay());
                }
                else
                {
                    // Display the warning message if score is not enough
                    StartCoroutine(DisplayWarningMessage());
                }
            }

        }
    }

    // Handles the door opening
    void OpenDoor()
    {
        // Create a new Vector3 and store current rotation
        Vector3 newRotation = transform.eulerAngles;

        // Add 90 degrees to the y axis rotation
        newRotation.y += -90f;

        // Assign the new rotation to the transform
        transform.eulerAngles = newRotation;

        opened = true;
    }

    // Coroutine to close the door after a delay
    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(openDuration);

        // Create a new Vector3 and store current rotation
        Vector3 newRotation = transform.eulerAngles;

        // Subtract 90 degrees from the y axis rotation to close the door
        newRotation.y -= -90f;

        // Assign the new rotation to the transform
        transform.eulerAngles = newRotation;

        opened = false;
    }


        // Coroutine to display the warning message
    private IEnumerator DisplayWarningMessage()
    {
        warningMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(messageDisplayTime);
        warningMessage.gameObject.SetActive(false);
    }
}
