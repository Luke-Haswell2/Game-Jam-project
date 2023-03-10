using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private Transform currentPoint;
    public float speed;
    private Animator anim;
    public GameObject Player;
    HealthAndCombat healthAndCombat;

    float nextAttack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentPoint = pointB.transform;
        anim = GetComponent<Animator>();
        healthAndCombat = GetComponent<HealthAndCombat>();
        healthAndCombat.OnDamage += OnDamage;
        healthAndCombat.OnDeath += OnDeath;
    }

    void DoAttack()
    {
        Player.GetComponent<HealthAndCombat>().DealDamage(20, Vector2.zero);
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            anim.SetBool("Walk", true);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            anim.SetBool("Walk", true);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
            sr.flipX = true;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
            sr.flipX = false;
        }
        if (Mathf.Abs(transform.position.x - Player.transform.position.x) <= 2)
        {
            if (Time.time >= nextAttack)
            {
                anim.SetTrigger("Attack");
                nextAttack = Time.time + 2;
                Invoke("DoAttack", 0.5f);
            }
        }
        else
        {
            anim.SetBool("Walk", true);
        }
    }
    void OnDamage(int amount)
    {
        anim.SetTrigger("Damage");
    }

    void OnDeath()
    {
        anim.SetTrigger("Death");
    }
}
