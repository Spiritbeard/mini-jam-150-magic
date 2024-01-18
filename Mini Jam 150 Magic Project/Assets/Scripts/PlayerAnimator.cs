using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(pm.direction != Vector2.zero)
        {
            am.SetBool("move", true);
            if(pm.direction.x != 0)
            {
                Flip();
            }
        }
        else
        {
            am.SetBool("move", false);
        }
    }

    void Flip()
    {
        if(pm.direction.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        
    }
}
