using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    public CarMovment carMovement;


    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);//2 in distance
        if (IsEnterCarPressed())
        {
            if (PlayerIsInCar())
            {
                LeaveCar();
            } else if (distance<2)
            {
                EnterCar();
            }
            
        }
    }

    void EnterCar()
    {
        Debug.Log("Enter Car");
        player.SetActive(false);
        carMovement.enabled = true;
    }

    void LeaveCar()
    {
        Debug.Log("Leave Car");
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
    

    bool IsEnterCarPressed()
    {
        return Input.GetButtonUp("Interact-Vehicle");
        
    }

    bool PlayerIsInCar()
    {
        return !player.activeInHierarchy;
    }
    
}
