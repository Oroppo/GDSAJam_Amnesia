using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    List<FallingItem> Spawnables = new List<FallingItem>();

    public int ChallengeLevel = 0;

    public void SpawnItem()
    {
        float rand = UnityEngine.Random.Range(0, 1);

        if (rand <= 0.2 && ChallengeLevel>2)
            Instantiate(Spawnables[0], transform.position, Quaternion.identity* Spawnables[0].transform.localRotation);

        else if (rand <= 0.4 && ChallengeLevel > 1)
            Instantiate(Spawnables[1], transform.position, Quaternion.identity * Spawnables[1].transform.localRotation);

        else 
            Instantiate(Spawnables[2],transform.position, Quaternion.identity * Spawnables[2].transform.localRotation);

    }
}
