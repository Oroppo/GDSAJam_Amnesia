using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwayne : FallingItem
{
    public int Hitpoints =3;
    public float InvulnerableTime = 0.5f;

    [SerializeField]
    private float shatterTime = 1.0f;

    IEnumerator ShatterCoroutine()
    {
        GetComponent<SpriteRenderer>().color = Color.red;


        for (int i =0; i<4;i++)
        {
            //Do shatter in 4 stages
            
            yield return new WaitForSeconds(shatterTime / 4);
        }
        base.ItemDeath();
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
            Hitpoints--;

        if (Hitpoints <= 0)
            StartCoroutine(ShatterCoroutine());
    }
}
