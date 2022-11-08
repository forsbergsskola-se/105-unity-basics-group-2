using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int movementSpeed;

    public int rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
            Rigidbody body = GetComponent<Rigidbody>();
            body.AddRelativeForce(0,0,movementSpeed * Time.fixedDeltaTime);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody body = GetComponent<Rigidbody>();
            body.AddRelativeForce(0,0,-movementSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.fixedDeltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.fixedDeltaTime, 0));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<CarLogic>().ExitCar();
        }
    }
}
