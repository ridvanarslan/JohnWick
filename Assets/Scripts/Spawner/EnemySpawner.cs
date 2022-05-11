using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Pool[] enemyPool;

    
    [Serializable]
    struct Pool
    {
        public GameObject enemyPrefab;
        public List<Transform> enemySpawnPositions;
        public int spawnCount;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < enemyPool.Length; i++)
        {
            for (int j = 0; j < enemyPool[i].enemySpawnPositions.Count; j++)
            {
                Transform spawnTransform = enemyPool[i].enemySpawnPositions[j];
                Instantiate(enemyPool[i].enemyPrefab, spawnTransform.position, Quaternion.identity, this.transform);
            }
        }
    }


}
