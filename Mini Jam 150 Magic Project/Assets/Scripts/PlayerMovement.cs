using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [HideInInspector] public Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void InputManagement()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        direction = new Vector2(xMovement, yMovement).normalized;
    }

    void Movement()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
