using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController : MonoBehaviour
{
    public LayerMask m_WhatIsGround,WhatIsWall;
    private Rigidbody2D RB;
    [Range(0, 15)] public float LRSpeed = 1, GroundedDistance=5;
    [HideInInspector] public bool CanJump = true;
    [Range(0, 25)] public float JumpHeight = 15;
    private Vector2 InputVec;
    // Start is called before the first frame update
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputVec = new Vector2(UnityEngine.Input.GetAxis("Horizontal"),0.0f);
       if(!IsWalled()) RB.velocity = new Vector2(InputVec.x* LRSpeed, RB.velocity.y);
        else RB.velocity = new Vector2(0, RB.velocity.y);
    }
    private void Update()
    {
        CanJump = isGrounded(GroundedDistance);
        if (UnityEngine.Input.GetButtonDown("Jump"))
            Jump();

        transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
    }
    private void Jump()
    {
        if (!CanJump) return;
        CanJump = false;
        RB.velocity = new Vector2(RB.velocity.x, JumpHeight);
    }

    public bool isGrounded(float x)
    {
        if (Physics2D.Raycast(transform.position + Vector3.right * GetComponent<BoxCollider2D>().size.x * transform.localScale.x / 2f, transform.rotation * Vector2.down, x, m_WhatIsGround))
            return true;
        else if (Physics2D.Raycast(transform.position + Vector3.left * GetComponent<BoxCollider2D>().size.x * transform.localScale.x / 2f, transform.rotation * Vector2.down, x, m_WhatIsGround))
            return true;
        else return false;
    }
    public bool IsWalled()
    {
        return Physics2D.Raycast(transform.position, transform.rotation *
            new Vector3(InputVec.normalized.x, InputVec.normalized.y, 0f), 0.75f, WhatIsWall);
    }
    private void OnDestroy()
    {
        Debug.Log("you suck");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right* GetComponent<BoxCollider2D>().size.x*transform.localScale.x/2f);
    }
}
