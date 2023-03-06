using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    HealthAndCombat healthAndCombat;
    Animator anim;
    SpriteRenderer sr;

    public float normalSpeedMultiplier = 1;
    public float powerupSpeedMultiplier = 1.5f;
    public float normalDamageMultiplier = 1;
    public float powerupDamageMultiplier = 1.5f;

    public Rect attackBoundingBox;

    float currentSpeedMultiplier;
    float currentDamageMultiplier;

    bool wantsJump;

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackBoundingBox.center, attackBoundingBox.size);
        Gizmos.DrawWireCube(new Vector2(-attackBoundingBox.center.x, attackBoundingBox.center.y), attackBoundingBox.size);
    }


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthAndCombat = GetComponent<HealthAndCombat>();
        healthAndCombat.OnDamage += OnDamage;
        healthAndCombat.OnDeath += OnDeath;

        currentSpeedMultiplier = normalSpeedMultiplier;
        currentDamageMultiplier = normalDamageMultiplier;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnDamage(int amount)
    {

    }

    void OnDeath()
    {
        anim.Play("PlayerDeath");
    }

    public IEnumerator ApplySpeedPowerup()
    {
        currentSpeedMultiplier = powerupSpeedMultiplier;
        yield return new WaitForSeconds(30);
        currentSpeedMultiplier = normalSpeedMultiplier;
    }
    public IEnumerator ApplyStrengthPowerup()
    {
        currentSpeedMultiplier = powerupDamageMultiplier;
        yield return new WaitForSeconds(30);
        currentSpeedMultiplier = normalDamageMultiplier;
    }
    public void ApplyLifePowerup()
    {
        healthAndCombat.Heal(20);
    }

    private void Update()
    {
        if (!healthAndCombat.alive) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wantsJump = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
        {
            anim.Play("Attack");
            int damage = (int)(10 * currentDamageMultiplier);
            Rect attackRect = attackBoundingBox;

            if (sr.flipX)
            {
                attackRect.center = new Vector2(-attackRect.center.x, attackRect.center.y);
            }
            healthAndCombat.TryAttack(attackRect, damage);

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            healthAndCombat.DealDamage(1000000, Vector2.zero);
        }
    }

    void FixedUpdate()
    {
        if (!healthAndCombat.alive) return;
        float verticalVel = 0;
        if (Input.GetKey(KeyCode.A))
        {
            verticalVel -= 1;
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            verticalVel += 1;
            sr.flipX = false;
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") || anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            if (Mathf.Abs(verticalVel) > 0.1)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
                    anim.Play("PlayerRun");
            }
            else
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    anim.Play("Idle");
            }
        }
        if (wantsJump)
        {
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            wantsJump = false;
        }
        rb.AddForce(new Vector2(verticalVel * currentSpeedMultiplier * 40 * rb.mass, 0));
    }
}
