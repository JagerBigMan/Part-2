using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        Controller.OnScoreUpdated += UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }
}
