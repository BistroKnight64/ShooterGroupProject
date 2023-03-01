using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] epilepsyprefabs;
    void Start()
    {
        SpawnEnemyWave(3);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    public int enemyCount;
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectOfType<Enemy>().Length;
        if(enemyCount == 0) { SpawnEnemyWave(1); }
    }
}
