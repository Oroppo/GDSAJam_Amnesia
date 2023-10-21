using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : FallingItem
{
    public LayerMask m_whatiswall;
    public bool Falling = false;
    public float FallTime = 3f, FallInterval = 0.01f;
    public int FallDir=0;
    // Start is called before the first frame update
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        FallDir = (CanFall(Vector3.right)) ? FallDir : 1;
        FallDir = (CanFall(Vector3.left)) ? FallDir : -1;

        if (!Falling) StartCoroutine(FallDown());
        else Destroy(collision.gameObject);
        //base.OnTriggerEnter2D(collision);
    }
    public IEnumerator FallDown()
    {
        GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
        Falling = true;
        float Duration = 0;
        while (Duration < FallTime)
        {
            yield return new WaitForSeconds(FallInterval);
            Duration += FallInterval;
            transform.RotateAround(transform.GetChild(0).position, Vector3.forward, FallDir*90f * (FallInterval / FallTime));
        }
        transform.rotation = Quaternion.Euler(0, 0, FallDir*90f);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        coll.isTrigger = false;
        //  ItemDeath();
    }
    public override void ItemDeath()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * coll.size.y * transform.localScale.y);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * (coll.size.y * transform.localScale.y)/2f);
    }
    public bool CanFall(Vector3 Direction)
    {
        return !Physics2D.Raycast(transform.position, Direction, coll.size.y * transform.localScale.y, m_whatiswall);
    }
}
