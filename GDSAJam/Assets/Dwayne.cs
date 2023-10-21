using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwayne : FallingItem
{
    public int Hitpoints =3;
    public float InvulnerableTime =0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ItemDeath()
    {
        Destroy(gameObject);  
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Hitpoints--;
        if (Hitpoints <= 0)
            ItemDeath();
    }
}
