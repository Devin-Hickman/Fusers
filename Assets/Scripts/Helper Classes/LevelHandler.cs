using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

public class LevelHandler
{
    EnemySpawner spawner;
    int currentLevel = 0;

    public float timeBetweenLevels = 30f;
    private float timeLevelEnded = 0;
    private bool forceLevelStart = false;


    void Awake()
    {
        spawner = GetComponent<EnemySpawner>();
    }
    void Start()
    {

    }

    void Update()
    {
       if(Time.time > timeLevelEnded + timeLevelEnded)
        {
            forceLevelStart = true;
        }
    }

    public void StartLevel()
    {
        currentLevel++;
        StartCoroutine(spawner.SpawnEnemy());
    }

    public void EndLevel()
    {
        Debug.Log("Level ended");
        StartCountdownUntilNextLevel();
        forceLevelStart = false;
        StartLevel();
    }

    public IEnumerator StartCoutdownUntilNextLevel()
    {
        timeLevelEnded = Time.time;
        yield return new waitUntil(() playerClickedNextLevel == true || forceLevelStart == true)
    }
 

}

