using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        // only, if the W-Key is currently pressed...
        if (Input.GetKey(KeyCode.W)) {
            // translate the player's transform-component on the y-axis (which points up)
            transform.Translate(0f, 0.01f, 0f);
        }
    }
}
