using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndCombat : MonoBehaviour
{
    public int maxHealth = 100;
    public event System.Action OnDeath;
    public event System.Action<int> OnDamage;
    public event System.Action<bool> OnKnockback;

    public int currentHealth;
    public bool alive => currentHealth > 0;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(int damageAmount, bool right)
    {
        if (!alive) return;

        OnDamage?.Invoke(damageAmount);
        OnKnockback?.Invoke(right);

        currentHealth -= System.Math.Min(damageAmount, System.Math.Max(currentHealth, 0));
        if (!alive)
        {
            OnDeath?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(0, currentHealth + amount);
    }
}
