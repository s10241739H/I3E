using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    public TextMeshProUGUI scoreText; // Score or points text UI
    public TextMeshProUGUI healthText; // Health Text UI
    public GameObject deathMesssage; // YOU DIE UI


    // Current score of the player
    int currentScore = 0;

    // Player's Health
    int health = 100;

    // Trigger for last door
    private bool initialTriggerAcitvated = false;

    // Increase the score of the player
    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
    }

    // Get the current score of the player
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // Decrease player health
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            PlayerDeath(); // Player dies
        }
    }


    // UI Death Message
    void PlayerDeath()
    {
        Debug.Log("You Died");
        deathMesssage.SetActive(true);
    }

    // Last door trigger, setting the trigger value
    public void SetInitialTriggerActivated(bool value)
    {
        initialTriggerAcitvated = value;
    }

    // Last door tigger, activating the trigger
    public bool IsInitialTriggerActivated()
    {
        return initialTriggerAcitvated;
    }

    // Start is called before the first frame update
    void Start()
    {
         healthText.text = "Health: " + health.ToString();
         deathMesssage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
