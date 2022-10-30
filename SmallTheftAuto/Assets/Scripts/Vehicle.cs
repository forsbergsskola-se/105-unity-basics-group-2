using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;

    public CarMovement carMovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (player.activeInHierarchy)
            {
                player.SetActive(false);
                carMovement.enabled = true;
            }

            player.transform.position = transform.position;
            player.SetActive(true);
            carMovement.enabled = false;
        }
    }
}
