using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public CarMovement carMovement;
    private GameObject player;

    public void EnterCar(GameObject player)
    {
        player.SetActive(false);
        carMovement.enabled = true;
        this.player = player;
    }

    public void LeaveCar()
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
}
