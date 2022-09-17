using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    // player reference ( probably needed to follow player)
    
    [SerializeField]
    private float minWaitTime = 1.5f, maxWaitTime = 3.5f;
    [SerializeField]
    private float damageTaken = 30f;
    [SerializeField]
    private float startingHealth = 100f;

    private float health {get; set;}
    private Rigidbody2D rb;
    private Animator animator;


    private float shootingTimer;
    private bool canShoot;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        health = startingHealth;
        shootingTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
        HandleShooting();
    }

    void HandleAnimations()
    {
        // shoot animation trigger
    }


    void HandleShooting()
    {
        if (Time.time > shootingTimer)
        {
            shootingTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
            Shoot();
        }

        if (rb.velocity.magnitude == 0)
            canShoot = true;
    }

    void Shoot()
    {
        if(canShoot)
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
            if (bullet != null) {
                //bullet.transform.position = turret.transform.position;
                //bullet.transform.rotation = turret.transform.rotation;
                //bullet.SetActive(true);
            }
        }
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
