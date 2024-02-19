using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int healthAmount = 20;
    public int scoreValue = 1;
    public int collectibleCountToWin = 15;
    private int collectedCount = 0;

    public Text scoreText;
    public GameObject victoryScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController player = other.GetComponent<CharacterController>();

            if (player != null)
            {
                player.GainHealth(healthAmount);
            }

            IncrementScore();
            CheckVictory();
            Destroy(gameObject);
        }
    }

    void IncrementScore()
    {
        collectedCount += scoreValue;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + collectedCount;
        }
    }

    void CheckVictory()
    {
        if (collectedCount >= collectibleCountToWin)
        {
            if (victoryScreen != null)
            {
                victoryScreen.SetActive(true);
            }
        }
    }
}
