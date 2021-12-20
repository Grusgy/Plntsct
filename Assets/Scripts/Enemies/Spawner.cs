using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public Wave[] waves;
    public float timeBetweenWaves;

    public Animator animator;

    private float timeBetweenWavesAtStart;

    private int i;
    public float timeAfterLastSpawn;


    private void Start()
    {
        timeAfterLastSpawn = 40;
        i = 0;
        timeBetweenWavesAtStart = timeBetweenWaves;
    }
    private void Update()
    {
        if(i <= waves.Length - 1)
        {
            timeBetweenWaves -= Time.deltaTime;

            if (timeBetweenWaves <= 0)
            {
                timeBetweenWaves = timeBetweenWavesAtStart;
                print(i);
                GameObject enemy = waves[i].enemy;
                int numberOfEnemies = waves[i].numberOfEnemies;
                for (int x = 0; x < waves[i].spawnPositions.Length; x++)
                {
                    Instantiate(enemy, spawnPos[waves[i].spawnPositions[x]]);
                }
                print("spawned");
                i++;
            }
        }
        else
        {
            timeAfterLastSpawn -= Time.deltaTime;
            if(timeAfterLastSpawn <= 0)
            {
                LevelFinished();
            }
        }
    }

    public void LevelFinished()
    {
        animator.SetTrigger("finished");
    }
}
