using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    private Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.x-5 <= Player.transform.position.x)
        {

        }
    }
}
