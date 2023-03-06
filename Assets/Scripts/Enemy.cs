using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if ((Player.transform.position.x < transform.position.x) && (transform.position.x-5 <= Player.transform.position.x))
        {
            rb.velocity = new Vector2 (-1, rb.velocity.y);
        }

        if ((Player.transform.position.x > transform.position.x) && (transform.position.x+5 >= Player.transform.position.x))
        {
            rb.velocity = new Vector2 (1, rb.velocity.y);
        }
    }
}
