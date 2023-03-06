using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum Effect
    {
        None,
        Speed,
        Life,
        Strength
    }
    public Effect effect;
    public int pointValue;
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Test");
        if (collision.CompareTag("Player"))
        {
            Score.score += pointValue;
            ApplyEffect(collision);
            Destroy(gameObject);
        }
    }

    void ApplyEffect(Collider2D collision)
    {
        switch (effect)
        {
            case Effect.Speed:
                StartCoroutine(collision.GetComponent<Player>().ApplySpeedPowerup());
                break;
            case Effect.Strength:
                StartCoroutine(collision.GetComponent<Player>().ApplyStrengthPowerup());
                break;
            case Effect.Life:
                collision.GetComponent<Player>().ApplyLifePowerup();
                break;
        }
    }
}
