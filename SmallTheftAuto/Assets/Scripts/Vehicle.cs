using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public CarMovement carMovement;

    public void EnterCar(GameObject player)
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    public void LeaveCar(GameObject player)
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
}
