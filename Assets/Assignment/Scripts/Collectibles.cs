using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public int healthAmount = 20;
    public int scoreValue = 1;
    public int collectibleCountToWin = 15;
    private int collectedCount = 0;

    public Text scoreText;
    public GameObject victoryScreen;

    void Start()
    {
        collectedCount = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreText();
    }

    void OnTriggerEnter2D(Collider2D Collectible)
    {
        if (Collectible.CompareTag("Player"))
        {
            CharacterController player = Collectible.GetComponent<CharacterController>();

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

        PlayerPrefs.SetInt("Score", collectedCount);
        PlayerPrefs.Save();
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
