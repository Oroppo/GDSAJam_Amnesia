using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    List<FallingItem> Spawnables = new List<FallingItem>();

    public int ChallengeLevel = 0;
    public float RaycastRange;

    public void BeginSpawn()
    {

        if (DetectIfOccupied())
            return;


        //do ur vfx here kai
        float rand = UnityEngine.Random.Range(0f, 1f);



        StartCoroutine(SpawnItem(rand));
    }
    public IEnumerator SpawnItem(float rand)
    {


        yield return new WaitForSeconds(1.0f);

        if (rand <= 0.2 && ChallengeLevel>2)
            Instantiate(Spawnables[0], transform.position, Quaternion.identity* Spawnables[0].transform.localRotation);

        else if (rand >= 0.2 && ChallengeLevel > 1&& rand <= 0.4)
            Instantiate(Spawnables[2], transform.position, Quaternion.identity * Spawnables[2].transform.localRotation);

        else if (rand >= 0.6 && ChallengeLevel > 3)
            Instantiate(Spawnables[3], transform.position, Quaternion.identity * Spawnables[1].transform.localRotation);

        else 
            Instantiate(Spawnables[1],transform.position, Quaternion.identity * Spawnables[1].transform.localRotation);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*RaycastRange );
       
    }
    private bool DetectIfOccupied()
    {
            return Physics2D.Raycast(transform.position, transform.rotation * Vector2.down, RaycastRange);        
    }
}
