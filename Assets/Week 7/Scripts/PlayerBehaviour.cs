using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public Color selectedColour;
    public Color unselectedColour;
    public float speed = 100;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            sr.color = selectedColour;
        }
        else
        {
            sr.color = unselectedColour;
        }
    }
        public void Move(Vector2 direction)
        {
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
}