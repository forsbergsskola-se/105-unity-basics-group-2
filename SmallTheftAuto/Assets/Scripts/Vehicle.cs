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
            else if (Vector3.Distance(player.transform.position, transform.position) < 3)
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
        if (player.activeInHierarchy)
            return false;
        return true;
    }

    public void EnterCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    public void LeaveCar()
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
}
