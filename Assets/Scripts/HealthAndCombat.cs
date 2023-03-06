using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndCombat : MonoBehaviour
{
    public enum Team
    {
        Player,
        Enemy
    }
    public Team team;
    public int maxHealth = 100;
    public event System.Action OnDeath;
    public event System.Action<int> OnDamage;
    public event System.Action<Vector2> OnKnockback;

    public int currentHealth;
    public bool alive => currentHealth > 0;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(int damageAmount, Vector2 knockbackVector)
    {
        if (!alive) return;

        OnDamage?.Invoke(damageAmount);
        OnKnockback?.Invoke(knockbackVector);

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

    public void TryAttack(Rect box, int amount, Vector2? knockbackVector = null, bool ignoreTeammates = true)
    {
        var knockbackVector_ = knockbackVector ?? Vector2.zero;

        var colliders = Physics2D.OverlapBoxAll(box.center, box.size, 0);
        foreach (Collider2D collider in colliders)
        {
            var target = collider.GetComponent<HealthAndCombat>();
            if (target == null) continue;
            if (ignoreTeammates && (team == target.team)) continue;

            target.DealDamage(amount, knockbackVector_);
        }
    }
}
