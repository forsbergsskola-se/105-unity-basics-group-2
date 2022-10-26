using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 40f;
    void Update()
    {
        // only, if the W-Key is currently pressed...
        float movement = Input.GetAxis ("Vertical"); 
        // translate the player's transform-component on the y-axis (which points up)
        transform.Translate(0f, movementSpeed * movement * Time.deltaTime, 0f);

        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0f,0f,-rotationSpeed * rotation * Time.deltaTime);
    }
}
