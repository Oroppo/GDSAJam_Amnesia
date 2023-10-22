using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController : MonoBehaviour
{
    public LayerMask m_WhatIsGround,WhatIsWall;
    private Rigidbody2D RB;
    [Range(0, 15)] public float LRSpeed = 1, GroundedDistance=5;

    [Range(0, 25)] public float JumpHeight = 15;

    Animator animator;

    [HideInInspector]
    #region Cached Properties
        private int _currentState;
        private static readonly int idle = Animator.StringToHash("Idle");
        private static readonly int run = Animator.StringToHash("Run");
        private static readonly int jump = Animator.StringToHash("Jump");
        private static readonly int fall = Animator.StringToHash("Fall");
        private static readonly int land = Animator.StringToHash("Land");
    #endregion

    private Vector2 InputVec;

    [HideInInspector] 
    public bool CanJump = true;
    private bool _grounded;
    private bool _jumpTriggered;
    private float _lockedTill;
    private bool _landed;

    private int GetState()
    {
        if (Time.time < _lockedTill) return _currentState;

        // Priorities
        if (_landed) return LockState(land, 0.2f);
        if (_jumpTriggered) return jump;

        if (_grounded) return InputVec.x == 0 ? idle : run;

        return RB.velocity.y > 0 ? jump : fall;

        int LockState(int s, float t)
        {
            _lockedTill = Time.time + t;
            return s;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputVec = new Vector2(UnityEngine.Input.GetAxis("Horizontal"),0.0f);
       if(!IsWalled()) RB.velocity = new Vector2(InputVec.x* LRSpeed, RB.velocity.y);
           else RB.velocity = new Vector2(0, RB.velocity.y);

        if (RB.velocity.x > 0f)
            GetComponent<SpriteRenderer>().flipX=false;
        else if (RB.velocity.x < 0f)
            GetComponent<SpriteRenderer>().flipX = true;
    }

    private void Update()
    {
        CanJump = isGrounded(GroundedDistance);
        _grounded = isGrounded(GroundedDistance);

        if (Input.GetButtonDown("Jump"))
            Jump(1f);

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        
        var state = GetState();
        _jumpTriggered = false;
        _landed = false;

        if (state == _currentState) return;
        animator.CrossFade(state, 0, 0);
        _currentState = state;
    }
    private void Jump(float Modifyer)
    {
        if (!CanJump) return;
        _jumpTriggered = true;
        CanJump = false;
        RB.velocity = new Vector2(RB.velocity.x, JumpHeight*Modifyer);
    }

    public bool isGrounded(float x)
    {
        if (Physics2D.Raycast(transform.position + Vector3.right * GetComponent<BoxCollider2D>().size.x * transform.localScale.x / 2f, transform.rotation * Vector2.down, x, m_WhatIsGround))
        {
            return true;
        }
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
    void OnTriggerEnter2D(Collider2D collider)
    {
            if(collider.gameObject.layer == LayerMask.NameToLayer("Lava"))
            {
            GetComponent<HealthSystem>().TakeDamage(1);
            Jump(1.5f);
            }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            GetComponent<HealthSystem>().TakeDamage(1);
            Jump(1.5f);
        }
    }
}
