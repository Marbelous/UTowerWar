using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    // Parameters for towers
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem bulletParticle;

    // State of towers
    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();

        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {

        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        //targetEnemy = closestEnemy.GetComponentInChildren<BoxCollider>().transform;
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform currentEnemy, Transform testEnemy)
    {
        var currentDist = Vector3.Distance(transform.position, currentEnemy.transform.position);
        var testDist = Vector3.Distance(transform.position, testEnemy.transform.position);

        return (currentDist < testDist) ? currentEnemy : testEnemy;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = bulletParticle.emission;
        emissionModule.enabled = isActive;
    }
}
