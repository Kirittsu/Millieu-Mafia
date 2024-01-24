using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private float spawnInterval = 2f;
    private float waveInterval = 3f;
    private int enemiesPerWave = 8;
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, _enemyPrefab.transform.rotation);
    }

    IEnumerator SpawnWaves()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 60f) // Spawn waves for at least 60 seconds
        {
            yield return new WaitForSeconds(waveInterval);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            currentWave++;
            Debug.Log("Wave " + currentWave + " completed!");

            elapsedTime += waveInterval;
        }
    }
}
