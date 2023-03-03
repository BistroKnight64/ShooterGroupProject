using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    // Start is called before the first frame update
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
    public Vector2 GenerateSpawnPosition()
    {
        float spawnposX = Random.Range(-spawnRange, spawnRange);
        float spawnsPosY = Random.Range(-spawnRange, spawnRange);
        Vector2 randomPos = new Vector3(spawnposX, 0, spawnsPosY);
        return randomPos;
    }
    public int enemyCount;
    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = FindObjectsOfType<playerchase>().Length;
        if(enemyCount == 0) { SpawnEnemyWave(1); }
    }
}
