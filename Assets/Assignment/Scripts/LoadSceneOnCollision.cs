using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with the character
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected!");
            // Get the index of the current scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Calculate the index of the next scene (cycling back to the first scene if at the end)
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
