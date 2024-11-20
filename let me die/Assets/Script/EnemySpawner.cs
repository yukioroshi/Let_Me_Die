using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab; // Assign your enemy prefab here
    public Transform player;       // Reference to the player
    public float spawnRadius = 10f;
    public float spawnInterval = 2f; // Seconds between spawns

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Random position around the player within the spawn radius
        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;

        // Spawn the enemy
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
