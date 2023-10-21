using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController : MonoBehaviour
{
    public LayerMask m_WhatIsGround;
    private Rigidbody2D RB;
    [Range(0, 15)] public float LRSpeed = 1, GroundedDistance=5;
    [HideInInspector] public bool CanJump = true;
    [Range(0, 25)] public float JumpHeight = 15;
    // Start is called before the first frame update
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vec = new Vector2(Input.GetAxis("Horizontal"),0.0f);
        RB.velocity = new Vector2(vec.x* LRSpeed, RB.velocity.y);      
    }
    private void Update()
    {
        CanJump = isGrounded(GroundedDistance);
        if (Input.GetButtonDown("Jump"))
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
        return Physics2D.Raycast(transform.position, transform.rotation * Vector2.down, x, m_WhatIsGround);
    }
}
