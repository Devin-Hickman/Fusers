using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class EnemySpawner : MonoBehaviour {

    private float timeBetweenEnemySpawns = 0.5f;

    public void setTimeBetweenEnemySpawns(float time) { timeBetweenEnemySpawns = time; }

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnEnemy");
        
		
	}
	

    public IEnumerator SpawnEnemy(IEnemy enemyToSpawn)
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject enemy = (GameObject) Instantiate(Resources.Load("Base enemy"));
            enemey.addComponent<enemyToSpawn>();
            enemy.transform.position = this.transform.position;
            yield return new WaitForSeconds(0.5f);
        }

    }
}
