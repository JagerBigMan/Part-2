using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazardPrefab; // Reference to the hazard prefab
    public float minX = -5f; // Minimum X position of spawn
    public float maxX = 5f; // Maximum X position of spawn
    public float spawnDelay = 1f; // Delay between spawns

    private float nextSpawnTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            // Set next spawn time
            nextSpawnTime = Time.time + spawnDelay;

            // Calculate random spawn position within specified range
            float spawnX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(spawnX, transform.position.y);

            // Instantiate hazard at the calculated position
            Instantiate(hazardPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
