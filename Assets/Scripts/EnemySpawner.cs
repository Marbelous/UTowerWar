using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.5f, 10f)]
    [SerializeField]
    float enemySpawnDelay = 2f;
    [SerializeField] EnemyMotion enemyPrefab;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        var delay = new WaitForSeconds(enemySpawnDelay);

        while (true)
        {
            print("spawning...");
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            yield return delay;
        }
    }
}
