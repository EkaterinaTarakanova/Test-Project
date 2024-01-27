using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemyInterval = 1.5f;
 
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemyInterval);
        }
    }
    private void SpawnEnemy()
    {
        float randomY = Random.Range(-4f, 4f);                
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);  
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
