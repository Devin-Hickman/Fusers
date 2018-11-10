using System.Collections;
using UnityEngine;
using Unity;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    private int currentLevel = 0;

    //TODO: Use scriptableObjects for level data. # Enemies, Type of Enemy, delay between spawn. Can use multiple scriptable objects for multiple delays?
    public float timeBetweenLevels = 30f;

    private float timeLevelEnded = 0;
    private bool forceLevelStart = false;
    public int numEnemiesOnLevel;
    private bool playerClickedNextLevel = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (Time.time > timeLevelEnded + timeLevelEnded)
        {
            forceLevelStart = true;
        }
    }

    public void PlayerClickedNextLevel()
    {
        //TODO: Prevent button from being clicked while level is in progress

        playerClickedNextLevel = true;
        StartLevel();
    }

    public void StartLevel()
    {
        //TODO: Change spawn delay & enemies spawn based on level
        float tempSpawnDelay = 0.5f;
        Debug.Log("Starting Next Level");
        GameObject enemy = (GameObject)Resources.Load("Enemy");
        currentLevel++;
        spawner.StartSpawningEnemies(enemy, numEnemiesOnLevel, tempSpawnDelay);
    }

    public void EndLevel()
    {
        //TODO: Add logic to determine if level ended when all enemies are dead or all enemies reach goal
        Debug.Log("Level ended");
        StartCoroutine("StartCountdownUntilNextLevel");
        forceLevelStart = false;
        playerClickedNextLevel = false;
        StartLevel();
    }

    public IEnumerator StartCoutdownUntilNextLevel()
    {
        timeLevelEnded = Time.time;
        yield return new WaitUntil(() => playerClickedNextLevel == true || forceLevelStart == true);
    }
}