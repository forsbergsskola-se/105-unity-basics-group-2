using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    public CarMovment carMovement;
    public float _distance;
    
    


    void Update()
    {
        _distance = Vector3.Distance(player.transform.position, transform.position);//2 in distance
        if (IsEnterCarPressed())
        {
            if (PlayerIsInCar())
            {
                LeaveCar();
            } else if (_distance<2)
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
