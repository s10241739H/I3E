using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door3 : MonoBehaviour
{
    // Flags if the door is open
    bool opened = false;

    public float moveDistance = 3.0f;
    public TextMeshProUGUI warningMessage; // Reference to the warning message UI
    public float messageDisplayTime = 2.0f; // Time to display the message

    public GameObject congratulationsPanel;
    public float congratulationsDisplayTime = 15.0f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if object entering the trigger is "Player" tag
        if (other.gameObject.tag == "Player" && !opened)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                if (player.IsInitialTriggerActivated())
                {
                    // If it's the player and the score is greater than 20, open the door
                    OpenDoor();
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
    public void OpenDoor()
    {
        if (!opened)
        {
            // Create a new Vector3 and store current position
            Vector3 newPosition = transform.position;

            // Add moveDistance to the y axis position
            newPosition.y += moveDistance;

            // Assign the new position to the transform
            transform.position = newPosition;

            opened = true;

            DisplayCongratulationsMessage();
        }
    }

    // Coroutine to display the warning message
    private IEnumerator DisplayWarningMessage()
    {
        warningMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(messageDisplayTime);
        warningMessage.gameObject.SetActive(false);
    }

    // Display Congrats Message
    private void DisplayCongratulationsMessage()
    {
        congratulationsPanel.SetActive(true);
        StartCoroutine(HideCongratulationsMessageAfterDelay());
    }

        private IEnumerator HideCongratulationsMessageAfterDelay()
    {
        yield return new WaitForSeconds(congratulationsDisplayTime);
        congratulationsPanel.SetActive(false);
    }
}
