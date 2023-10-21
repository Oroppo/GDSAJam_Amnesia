using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class FallingItem : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider2D coll;
    public float SinkTime = 3f, SinkInterval = 0.01f;
    [HideInInspector] public bool Sinking = false;
    public virtual void OnValidate()
    {
        if (!coll)
        {
            coll = GetComponent<BoxCollider2D>();
            coll.isTrigger = true;
        }
       
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //do stuff once in lava
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            BeginItemInteraction();
        if (collision.gameObject.layer == 2)
            BeginItemInteraction();
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
       
        //6 is the lava layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
            HitLava();

   
    }
    public void StunPlayer()
    {

    }
    public virtual void BeginItemInteraction()
    {
        if (Sinking) return;
        StartCoroutine(SinkDeBoi());
    }
    public virtual IEnumerator SinkDeBoi()
    {
        Sinking = true;
        float Duration = 0;
        while (Duration<SinkTime)
        {          
            yield return new WaitForSeconds(SinkInterval);
            Duration += SinkInterval;
            coll.size = new Vector2(1f- Duration / SinkTime,1);
            coll.offset = new Vector2((1f - coll.size.x)/2f, 0);
        }
        ItemDeath();
    }
    public virtual void ItemDeath()
    {
        Destroy(gameObject);
    }
    public virtual void HitLava()
    {
        coll.isTrigger = false;
    }
}
