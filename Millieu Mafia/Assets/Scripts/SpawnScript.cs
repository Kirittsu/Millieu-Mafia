using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    
    private float spawnInterval = 7f;
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
