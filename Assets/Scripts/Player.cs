using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    HealthAndCombat healthAndCombat;

    public float normalSpeedMultiplier = 1;
    public float powerupSpeedMultiplier = 1.5f;
    public float normalDamageMultiplier = 1;
    public float powerupDamageMultiplier = 1.5f;

    float currentSpeedMultiplier;
    float currentDamageMultiplier;

    bool wantsJump;


    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wantsJump = true;
        }
    }

    void FixedUpdate()
    {
        float verticalVel = 0;
        if (Input.GetKey(KeyCode.A))
        {
            verticalVel -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            verticalVel += 1;
        }
        if (wantsJump)
        {
            rb.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            wantsJump = false;
        }
        rb.AddForce(new Vector2(verticalVel * currentSpeedMultiplier * 40 * rb.mass, 0));
    }
}
