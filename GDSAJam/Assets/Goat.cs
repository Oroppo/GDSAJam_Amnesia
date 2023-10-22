using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : FallingItem
{
    public LayerMask WhatIsJumpable;
    public float GoatJumpRange = 1;
    public Transform TargetPlatform, CurrentPlatform;
    public float GoatJumpHeight, GoatJumpTime;
    public int TotalJumps = 3;
    public Transform IHateTheGoat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var colls = Physics2D.OverlapCircleAll(GetComponent<Rigidbody2D>().position, GoatJumpRange, WhatIsJumpable);
        TargetPlatform = GetClosestEnemy(colls);
    }

    public override void HitLava()
    {
        base.HitLava();
        Invoke(nameof(BeginJump), 2.0f);
    }
    public void BeginJump()
    {
        if(TargetPlatform)
        StartCoroutine(Jump(transform.position,TargetPlatform.position+Vector3.up));
        else StartCoroutine(Jump(transform.position, transform.position + Vector3.up));
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    private IEnumerator Jump(Vector3 P1, Vector3 P2)
    {
        if (TotalJumps <= 0)
            ItemDeath();
        Vector3 center = transform.position + ((P2 - transform.position) / 2f) + Vector3.up * GoatJumpHeight;
        float Journey = 0;
        while (Journey < GoatJumpTime)
        {
            Vector3 P3 = P1 + Vector3.up * GoatJumpHeight;
            Vector3 P4 = P2 + Vector3.up * GoatJumpHeight;
            yield return new WaitForSeconds(0.01f);
            Journey += 0.01f;
         
            transform.position = CalculateCubicBezierPoint(P1, P3, P4, P2, (Journey / GoatJumpTime));
        }
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        TotalJumps--;
        CurrentPlatform = GetPlatform();
        Invoke(nameof(BeginJump), 2.0f);
    }
    public Transform GetPlatform()
    {
        RaycastHit2D thang = Physics2D.Raycast(transform.position, Vector2.down, 9f, WhatIsJumpable);

        return thang.transform;
    }
    public static Vector3 CalculateCubicBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0 + 3 * uu * t * p1 + 3 * u * tt * p2 + ttt * p3;

        return p;
    }
    Transform GetClosestEnemy(Collider2D[] colls)
    {
        //legacy
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Collider2D potentialTarget in colls)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr&&potentialTarget.transform != CurrentPlatform && potentialTarget.transform != IHateTheGoat)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;
    }
    public override void ItemDeath()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, GoatJumpRange);
        if(TargetPlatform)
        Gizmos.DrawSphere(transform.position+((TargetPlatform.position-transform.position) / 2f)+Vector3.up*GoatJumpHeight, 0.15f);
    }
}
