using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    List<SpawnerBehaviour> Spawners = new List<SpawnerBehaviour>();
    public static SpawnManager singleton; 

    [SerializeField]
    float SpawnInterval = 2.5f;

    int spawnCount = 0;

    int lastSpawner;
    public bool LogExists =false;

    [SerializeField]
    int spawnsUntilChallengeUp = 5;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        //should happen after cutscene
        StartCoroutine(SpawnCoroutine());
        Debug.Log("Spawn Coroutine Started");
    }

    IEnumerator SpawnCoroutine()
    {
        int rand;
        do
            rand = UnityEngine.Random.Range(0, Spawners.Count);       
        while 
            (rand == lastSpawner);

        Spawners[rand].BeginSpawn();
        lastSpawner = rand;

        Debug.Log("Item Spawned at spawner: " + rand);
        CheckChallengeLvl();

        yield return new WaitForSeconds(SpawnInterval);

        StartCoroutine(SpawnCoroutine());
    }

    private void CheckChallengeLvl()
    {
        spawnCount++;
        if (spawnCount % spawnsUntilChallengeUp == 0)
        {
            foreach (var spawn in Spawners)
            {
                spawn.ChallengeLevel++;
            }
        }
    }
}
