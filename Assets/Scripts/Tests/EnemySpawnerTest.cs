using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Testtools;

namespace Tests
{
    public class EnemySpawnerTest
    {
        /// <summary>
        /// Spawns a single enemy using the enemy spawner class
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator Spawn_Single_Enemy_Test()
        {
            EnemySpawner enemySpawner = new EnemySpawner();
            GameObject enemyPrefab = (GameObject)Resources.Load("grunt");
            enemySpawner.EnemyToSpawn = enemyPrefab;

            yield return null;

            var spawnedEnemy = GameObject.FindWithTag("Enemy");


            Assert.AreEqual(enemyPrefab, spawnedEnemy);
        }

        [TearDown]
        private void RemoveAllObjectsFromScence()
        {
            foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Enemy"){
                Object.Destroy(gameObject);
            }
            foreach(GameObject gameObject in Object.FindObjectOfType<EnemySpawner>)
            {
                Object.Destroy(gameObject);
            }
        }
    }
}
