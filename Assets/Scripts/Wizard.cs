using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    private Animator anim;
    SpriteRenderer sr;
    HealthAndCombat healthAndCombat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthAndCombat = GetComponent<HealthAndCombat>();
        healthAndCombat.OnDamage += OnDamage;
        healthAndCombat.OnDeath += OnDeath;
    }

    void Update()
    {
        if (transform.position.x-5 <= Player.transform.position.x)
        {
            anim.SetBool("Attack", true);
        }
        if (transform.position.x-5 > Player.transform.position.x)
        {
            anim.SetBool("Idle", true);
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
