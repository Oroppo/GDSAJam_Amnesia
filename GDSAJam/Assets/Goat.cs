using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : FallingItem
{
    public LayerMask WhatIsJumpable;
    public float GoatJumpRange = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var colls = Physics2D.OverlapCircleAll(GetComponent<Rigidbody2D>().position, GoatJumpRange, WhatIsJumpable);
        foreach(Collider2D coll in colls)
            Debug.Log(coll.gameObject.name);
    }
    public override void ItemDeath()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, GoatJumpRange);
    }
}
