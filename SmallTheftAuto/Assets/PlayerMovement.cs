using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        // only, if the W-Key is currently pressed...
        if (Input.GetKey(KeyCode.W)) {
            // translate the player's transform-component on the y-axis (which points up)
            transform.Translate(0f, 2f * Time.deltaTime, 0f);
        }
        
        // only, if the S-Key is currently pressed...
        if (Input.GetKey(KeyCode.S)) {
            // translate the player's transform-component on the y-axis
            transform.Translate(0f, -2f * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, 40f * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -40f * Time.deltaTime);
        }
    }
}
