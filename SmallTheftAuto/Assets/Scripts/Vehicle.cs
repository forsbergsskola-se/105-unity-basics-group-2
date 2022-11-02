using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private GameObject player;
    public CarMovment carMovement;
    
    public void EnterCar(GameObject player)
    {
        Debug.Log("Enter Car");
        player.SetActive(false);
        carMovement.enabled = true;
        this.player = player;
    }

    public void LeaveCar()
    {
        Debug.Log("Leave Car");
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
    

    

    
    
}
