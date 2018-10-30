using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class EnemySpawner : MonoBehaviour {

    private float timeBetweenEnemySpawns = 0.5f;
    private float timeOfLastSpawn = 0;
    private GameObject enemyToSpawn;

    public GameObject EnemyToSpawn { get => enemyToSpawn; set => enemyToSpawn = value; }

    public void setTimeBetweenEnemySpawns(float time) { timeBetweenEnemySpawns = time; }

    //TODO: Add way to set what enemy type is spawned per level

    void Update()
    {
        if(Time.time > timeOfLastSpawn + timeBetweenEnemySpawns)
        {
            SpawnEnemy(10);
            timeOfLastSpawn = Time.time;
        }

    }

    public void SpawnEnemy(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Base enemy"));
            enemey.addComponent<enemyToSpawn>();
            enemy.transform.position = this.transform.position;
        }
    }
	

    public void SpawnEnemy(IEnemy enemyToSpawn, int numEnemies)
    {
        for(int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = (GameObject) Instantiate(Resources.Load("Base enemy"));
            enemey.addComponent<enemyToSpawn>();
            enemy.transform.position = this.transform.position;
        }
    }

}
