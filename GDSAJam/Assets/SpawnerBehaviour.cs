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

        Debug.Log(DetectIfOccupied());

        if (DetectIfOccupied())
            return;


        //do ur vfx here kai
        float rand = UnityEngine.Random.Range(0f, 1f);
        //for tree vfx
        if (rand <= 0.2 && ChallengeLevel > 2 && !SpawnManager.singleton.LogExists)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        //for body vfx
        if ((rand >= 0.2 && ChallengeLevel > 1 && rand <= 0.4) == false && (rand >= 0.6 && ChallengeLevel > 3) == false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        
        //for goat VFX
        if(rand >= 0.6 && ChallengeLevel > 3)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }


        StartCoroutine(SpawnItem(rand));
    }
    public IEnumerator SpawnItem(float rand)
    {
        Debug.Log(DetectIfOccupied());

       // yield return new WaitForSeconds(0.01f);

        //vfx
        //if a body indicator is enabled then disable it
        if(transform.GetChild(1).gameObject.active == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }



        //Tree
        if (rand <= 0.2 && ChallengeLevel > 2 && !SpawnManager.singleton.LogExists)
        {
            //vfx
            yield return new WaitForSeconds(3.0f);
            //if a tree indicator is enabled then disable it
            if (transform.GetChild(0).gameObject.active == true)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }

            Instantiate(Spawnables[0], transform.position, Quaternion.identity * Spawnables[0].transform.localRotation);
            SpawnManager.singleton.LogExists = true;
        }
        //Rock 
        else if (rand >= 0.2 && ChallengeLevel > 1 && rand <= 0.4)
            Instantiate(Spawnables[2], transform.position, Quaternion.identity * Spawnables[2].transform.localRotation);

        //Goat
        else if (rand >= 0.8 && ChallengeLevel > 3)
        {
            yield return new WaitForSeconds(2.0f);
            //vfx
            if (transform.GetChild(2).gameObject.active == true)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }
            Instantiate(Spawnables[3], transform.position, Quaternion.identity * Spawnables[3].transform.localRotation);
        }
        //Bodies
        else
            Instantiate(Spawnables[1], transform.position, Quaternion.identity * Spawnables[1].transform.localRotation);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*RaycastRange );
       
    }
    private bool DetectIfOccupied()
    {
      // Debug.Log(Physics2D.Raycast(transform.position, transform.rotation * Vector2.down, RaycastRange).transform.name);
        return Physics2D.Raycast(transform.position, Vector2.down, RaycastRange);        
    }
}
