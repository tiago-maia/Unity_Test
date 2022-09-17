using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy : MonoBehaviour
{

    // player reference ( probably needed to follow player)
    
    [SerializeField]
    private float minJumpForce = 5f, maxJumpForce = 12f;
    [SerializeField]
    private float minWaitTime = 1.5f, maxWaitTime = 3.5f;
    [SerializeField]
    private float damageTaken = 30f;
    [SerializeField]
    private float startingHealth = 100f;

    private float health {get; set;}
    private Rigidbody2D rb;
    private Animator animator;


    private float jumpTimer;
    private bool canJump;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        health = startingHealth;
        jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        HandleJumping();
        HandleAnimations();
    }

    void HandleAnimations()
    {
        if (rb.velocity.magnitude == 0)
            animator.SetBool("Jump", false);
        else
            animator.SetBool("Jump", true);
    }

    void Jump()
    {
        if (canJump)
        {
            canJump = false;
            rb.velocity = new Vector2(0f, Random.Range(minJumpForce, maxJumpForce));
        }
    }

    void HandleJumping()
    {
        if (Time.time > jumpTimer)
        {
            jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
            Jump();
        }

        if (rb.velocity.magnitude == 0)
            canJump = true;
    }


    void TakeDamage()
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Death();
        }
    }

    void DoDamage()
    {
        // animation to attack
    }

    void Death()
    {
        // animation to die
        // destroy object
    }
}
