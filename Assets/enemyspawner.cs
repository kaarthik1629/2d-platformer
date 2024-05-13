using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform[] movePoints; // Array of move points for enemies
    
    public int numberOfEnemies = 5; // Number of enemies to spawn

    private int enemiesSpawned = 0;
    

    private void Start()
    {
        // Start spawning enemies
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        while (enemiesSpawned < numberOfEnemies)
        {
            // Instantiate a new enemy prefab
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Assign move points to the enemy if available
            if (movePoints.Length > 0)
            {
                // Create a new array to hold the move points for this enemy
                Transform[] enemyMovePoints = new Transform[movePoints.Length];

                // Copy the move points to the enemy-specific array
                for (int i = 0; i < movePoints.Length; i++)
                {
                    enemyMovePoints[i] = movePoints[i];
                }

                // Set the enemy's move points
                newEnemy.GetComponent<moving>().SetMovePoints(enemyMovePoints);
            }

            enemiesSpawned++;

            // Ensure the loop doesn't continue until the first enemy is destroyed
            break;
        }
    }
}
