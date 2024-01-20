using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.FilePathAttribute;

public class Headlight : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 250f;
    }

    private void OnEnable()
    {
        PlayerMovement.onPlayerLook += RotateToPlayerDirection;
    }

    private void OnDisable()
    {
        PlayerMovement.onPlayerLook -= RotateToPlayerDirection;
    }
   
    private void RotateToPlayerDirection(Quaternion toRotation)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
