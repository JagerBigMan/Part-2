using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform kickoffSpot;
    public float resetDelay = 2f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            Controller.UpdateScore(Controller.Score + 1);

            Invoke("ResetBall", resetDelay);
        }
    }

    private void ResetBall()
    {
        transform.position = kickoffSpot.position;
        rb.velocity = Vector2.zero;
    }
}