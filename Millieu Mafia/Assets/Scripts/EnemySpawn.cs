using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject _enemyPrefab;
    public float spawnInterval = 7f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, _enemyPrefab.transform.rotation);
    }
}
