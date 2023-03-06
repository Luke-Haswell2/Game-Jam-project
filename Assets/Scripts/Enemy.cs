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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentPoint = pointB.transform;
        anim = GetComponent<Animator>();
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
    }
}
