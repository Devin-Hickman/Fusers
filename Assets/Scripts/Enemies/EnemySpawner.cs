using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnEnemy");
        
		
	}
	

    public IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject enemy = (GameObject) Instantiate(Resources.Load("Grunt"));
            enemy.transform.position = this.transform.position;
            yield return new WaitForSeconds(0.5f);
        }

    }
}
