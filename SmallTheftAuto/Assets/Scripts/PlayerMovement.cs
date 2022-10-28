using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0.01f , 0f*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -0.01f, 0f*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0.01f, 0f*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, -0.01f , 0f*Time.deltaTime);
            
        }
    }
}
