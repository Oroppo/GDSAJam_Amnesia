using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : FallingItem
{
    public LayerMask m_whatiswall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log(CanFall(Vector3.right)+ " Right");
        Debug.Log(CanFall(Vector3.left) + " Left");
    }
    public override void ItemDeath()
    {
        throw new System.NotImplementedException();
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
