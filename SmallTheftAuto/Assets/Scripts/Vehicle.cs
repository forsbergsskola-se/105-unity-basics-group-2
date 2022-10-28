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
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("F is pressed");
            if (player.activeInHierarchy) //It is true
            {
                Debug.Log("Enter Car");
                player.SetActive(false);
                carMovement.enabled = true;
            } else
            {
                Debug.Log("Leave Car");
                player.transform.position = transform.position;
                player.SetActive(true);
                carMovement.enabled = false;
            }
        }


    }
}
