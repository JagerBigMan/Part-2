using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector3 targetPosition;

    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;

    private int score = 0;
    private int highScore = 0;

    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;

        UpdateHealthBar();
        UpdateScoreText();
        LoadHighScore();
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
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    public void GainHealth(int healthAmount)
    {
        currentHealth += healthAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();
    }

    void Die()
    {
        Debug.Log("Character has died");
        SceneManager.LoadScene("GameOverScene");
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }

    public void CollectCollectible()
    {
        score++;
        UpdateScoreText();

        if (score >= 15)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    void OnDestroy()
    {
        SaveHighScore();
    }
}
