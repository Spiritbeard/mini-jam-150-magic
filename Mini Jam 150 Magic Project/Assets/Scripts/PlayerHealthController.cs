using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    public static event Action<int> OnHealthChange;
    public static event Action OnPlayerDefeated;

    private void OnEnable()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    void IncrementHealth(int healthChange)
    {
        health += healthChange;
        if (health > maxHealth)
            health = maxHealth;

        OnHealthChange?.Invoke(health);

        if (health <= 0)
        {
            OnPlayerDefeated?.Invoke();
        }
    }
}
