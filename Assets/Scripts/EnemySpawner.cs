using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float enemySpawnDelay = 5f;
    [SerializeField] EnemyMotion enemyPrefab;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(enemySpawnDelay);
    }
}
