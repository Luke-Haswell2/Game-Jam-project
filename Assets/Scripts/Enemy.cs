using System.Collections;
using System.Collections.Generic;
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
        if ((transform.position.x-2 <= Player.transform.position.x) || (transform.position.x+2 >= Player.transform.position.x))
        {
                anim.SetBool("Attack", true);
        }
        if ((transform.position.x-2 > Player.transform.position.x) || (transform.position.x+2 < Player.transform.position.x))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Attack", false);
        }
    }
    void OnDamage(int amount)
    {

    }

    void OnDeath()
    {

    }
}
