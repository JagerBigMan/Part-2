using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;
    public static FootballPlayer SelectedPlayer { get; private set; }
    public static int Score { get; private set; }
    public static Controller Instance { get; private set; }

    public delegate void ScoreUpdated(int newScore);
    public static event ScoreUpdated OnScoreUpdated;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static void SetSelectedPlayer(FootballPlayer player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        player.Selected(true);
        SelectedPlayer = player;
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
    }

    private void Update()
    {
        if (SelectedPlayer == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectedPlayer.transform.position).normalized * charge;
        }
    }

    public static void UpdateScore(int newScore)
    {
        Score = newScore;

        OnScoreUpdated?.Invoke(Score);
    }
}