using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range (0, 40)] int poolSize = 5;
    [SerializeField] [Range(0.5f, 20f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int iterator = 0; iterator < pool.Length; iterator++)
        {
            pool[iterator] = Instantiate(enemyPrefab, transform);
            pool[iterator].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int iterator = 0; iterator < pool.Length; iterator++)
        {
            if(pool[iterator].activeInHierarchy == false)
            {
                pool[iterator].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
