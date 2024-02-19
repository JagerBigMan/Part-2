using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int healthAmount = 20; // Amount of health the collectible gives to the player

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collectible collides with the player
        if (other.CompareTag("Player"))
        {
            CharacterController player = other.GetComponent<CharacterController>(); // Get the CharacterController component from the player

            // Check if the player script is attached to the player
            if (player != null)
            {
                player.GainHealth(healthAmount); // Call the GainHealth function of the player script with the healthAmount
            }

            Destroy(gameObject); // Destroy the collectible GameObject
        }
    }
}
