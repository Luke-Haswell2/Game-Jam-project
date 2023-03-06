using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    enum Effect
    {
        None,
        Speed,
        Life,
        Strength
    }
    Effect effect;
    public int pointValue;
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Test");
        if (collision.CompareTag("Player"))
        {
            Score.score += pointValue;
            Destroy(gameObject);
        }
    }

    void ApplyEffect()
    {
        switch (effect)
        {

        }
    }
}
