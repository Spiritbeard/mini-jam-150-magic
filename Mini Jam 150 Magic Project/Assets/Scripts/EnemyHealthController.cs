using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    // Start is called before the first frame update
    void OnEnable()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    public void IncrementHealth(int healthChange)
    {
        health += healthChange;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject, 0f);
        }
    }

}
