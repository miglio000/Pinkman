using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D coll;
    SpriteRenderer sprite;
    Animator animator;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSound;

    float dirX = 0f;
    [SerializeField] float movespeed = 7f;
    [SerializeField] float jumpforce = 12f;

    enum MovementState { idle, running, jump, fall}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        //directions
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpSound.Play();
        }
        //animations 
        UpdateAnimations();


    }

    void UpdateAnimations()
    {
        MovementState status;
        if (dirX > 0f)
        {
            status = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            status = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            status = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            status = MovementState.jump;
        }
        else if (rb.velocity.y < -.001f)
        {
            status = MovementState.fall;
        }

        animator.SetInteger("status", (int)status);
    }


    bool IsGrounded() 
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .01f, jumpableGround);   
    }
}
