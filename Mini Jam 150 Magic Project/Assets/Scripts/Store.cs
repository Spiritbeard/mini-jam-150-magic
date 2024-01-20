using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    bool isInside;
    [SerializeField] private TextMeshPro tm;

    void Update()
    {
        if(isInside)
        {
            tm.text = "player can buy stuff";
        }
        else
        {
            tm.text = "player can NOT buy stuff";
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            isInside = false;
        }
    }
}
