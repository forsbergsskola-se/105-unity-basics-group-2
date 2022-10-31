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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnterCarButtonPressed())
        {
            Debug.Log("AAAAAA");
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
        player.transform.SetPositionAndRotation(transform.position,new Quaternion(0,0,0,0));
        player.SetActive(true);
        carMovement.enabled = true;
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
