using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;

    public CarMovement carMovement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (EnterCarButtonPressed())
        {
            if (PlayerIsInCar())
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 100)
                {
                    EnterCar();
                }
            }
            else
            {
                LeaveCar();
            }
        }
    }

    void EnterCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    void LeaveCar()
    {
        Vector3 newPlayerPosition = transform.right;
        newPlayerPosition.y += 2;
        player.transform.SetPositionAndRotation(newPlayerPosition,new Quaternion(0,0,0,0));
        player.SetActive(true);
        carMovement.enabled = false;
    }

    bool EnterCarButtonPressed()
    {
        return Input.GetButton("Interact-Vehicle");
    }
    bool PlayerIsInCar()
    {
        return player.activeInHierarchy;
    }
}
