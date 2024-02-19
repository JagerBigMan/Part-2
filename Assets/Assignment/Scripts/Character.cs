using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector3 targetPosition;

    public int maxHealth = 100; // Maximum health points for the character
    private int currentHealth; // Current health points for the character

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Initialize current health to max health
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
        }

        Vector2 direction = (targetPosition - transform.position).normalized;

        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by the damage amount

        // Check if current health has dropped to zero or below
        if (currentHealth <= 0)
        {
            Die(); // Call Die function if the character's health reaches zero
        }
    }

    void Die()
    {
        // Implement death logic here (e.g., play death animation, disable character, etc.)
        Debug.Log("Character has died");
    }
}
