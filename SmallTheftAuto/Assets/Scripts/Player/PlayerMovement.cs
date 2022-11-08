using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int movementSpeed;

    public int rotationSpeed;
    
    public PlayerStats  playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.health >= 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
            }
        }
    }
}
