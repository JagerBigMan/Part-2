using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHealth : MonoBehaviour
{
    private const string knightHealthKey = "KnightHealth";
    private const int defaultHealth = 10;

    // Function to set knight's health
    public static void SetKnightHealth(int health)
    {
        PlayerPrefs.SetInt(knightHealthKey, health);
    }

    // Function to get knight's health
    public static int GetKnightHealth()
    {
        return PlayerPrefs.GetInt(knightHealthKey, defaultHealth);
    }

    // Function to update knight's health
    public static void UpdateKnightHealth(int newHealth)
    {
        PlayerPrefs.SetInt(knightHealthKey, newHealth);
    }

    void Start()
    {
        // Example usage:
        int knightHealth = GetKnightHealth();
        Debug.Log("Knight's Health: " + knightHealth);
    }
}
