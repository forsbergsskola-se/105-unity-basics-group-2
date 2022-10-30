using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;

    public CarMovement carMovement;

    void Update()
    {
        if (EnterCarButtonPressed())
        {
            if (PlayerIsInCar())
            {
                LeaveCar();
            }
            else
            {
                EnterCar();
            }
        }
    }

    public bool EnterCarButtonPressed()
    {
        return Input.GetKey(KeyCode.F);
    }

    public bool PlayerIsInCar()
    {
        return player.activeInHierarchy;
    }

    public void LeaveCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    public void EnterCar()
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
}
