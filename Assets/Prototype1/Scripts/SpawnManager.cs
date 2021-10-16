using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9f;
    public int enemyCount;
    private int maxNumber = 5;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    void Start() {
        SpawnEnemyWave(waveNumber);
        PowerupSpawn(waveNumber);
    }

    private void Update(){
        enemyCount = FindObjectsOfType<Enemy>().Length;
         
        if (enemyCount <= 0 && waveNumber < maxNumber)
        {
            waveNumber++;
            PowerupSpawn(waveNumber);
            SpawnEnemyWave(waveNumber);
        }

        else if (enemyCount <= 0)
        {
            PowerupSpawn(waveNumber);
            SpawnEnemyWave(waveNumber);
        }
    }

    Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1f, spawnPosZ);
        return randomPos; }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
    void PowerupSpawn(int powerupToSpawn)
    {
        for (int i = 0; i < powerupToSpawn; i++)
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

}
