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
        if (IsEnterCarPressed())
        {
            if (PlayerIsInCar()) //It is true !
            {
                LeaveCar();
            } else
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
        return Input.GetKeyUp(KeyCode.F);
    }

    bool PlayerIsInCar()
    {
        return !player.activeInHierarchy;
    }
}
