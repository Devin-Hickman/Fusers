using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class EnemySpawner : MonoBehaviour {

    private float timeBetweenEnemySpawns = 0.5f;
    private float timeOfLastSpawn = 0;

    public void setTimeBetweenEnemySpawns(float time) { timeBetweenEnemySpawns = time; }

    //TODO: Add way to set what enemy type is spawned per level

    void Update()
    {
        if(Time.time > timeOfLastSpawn + timeBetweenEnemySpawns)
        {
            timeOfLastSpawn = Time.time;
        }

    }

    public void StartSpawningEnemies(GameObject enemyToSpawn, int numEnemies, float spawnDelay)
    {
        StartCoroutine(SpawnEnemy(enemyToSpawn, numEnemies, spawnDelay));
    }

    private IEnumerator SpawnEnemy(GameObject enemyToSpawn, int numEnemies, float spawnDelay)
    {
        for(int i = 0; i < numEnemies; i++)
        {
            Debug.Log("Spawning Enemy");
            GameObject enemy = (GameObject) Instantiate(Resources.Load("Grunt"));
            enemy.transform.position = this.transform.position;
            yield return new WaitForSeconds(spawnDelay);

        }
    }

}
