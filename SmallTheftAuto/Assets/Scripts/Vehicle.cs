using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;

    public CarMovment carMovement;
    
    

     void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("F is pressed");
            if (player.activeInHierarchy) //It is true
            {
                player.SetActive(false);
                carMovement.enabled = true;
            } else
            {
                transform.position = player.transform.position * Time.deltaTime;
                player.SetActive(true);
                carMovement.enabled = false;
            }
        }


    }
}
