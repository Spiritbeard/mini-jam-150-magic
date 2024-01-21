using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private int damage;

    void OnEnable()
    {
        damage = 1;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyHurtbox")
        {
            collider.gameObject.GetComponent<EnemyHealthController>().IncrementHealth(-damage);
        }
    }
}
