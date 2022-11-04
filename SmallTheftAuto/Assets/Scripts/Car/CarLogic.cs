using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class CarLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    private GameObject mainCamera;
    private ParticleSystem particles;
    public PlayerStats playerStats;
    public float exitOffset;
    public float health;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        var emission = particles.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterCar(GameObject player)
    {
        this.player = player;
        mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraBehaviour>().NewFocus(gameObject);
        GetComponent<CarMovement>().enabled = true;
        player.SetActive(false);
    }

    public void ExitCar()
    {
        GetComponent<CarMovement>().enabled = false;
        Vector3 newPlayerPosition = transform.position;
        newPlayerPosition += (transform.right * exitOffset);
        player.transform.position = newPlayerPosition; //Might be problematic in the future
        
        mainCamera.GetComponent<CameraBehaviour>().NewFocus(player);
        player.SetActive(true);
        player = null;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.1f)
        {
            health -= collision.relativeVelocity.magnitude;
            Debug.Log("Magnitude was high enough");
        }
        Debug.Log("velocity magnitude was: " + collision.relativeVelocity.magnitude);
        Debug.Log("New car health is: " + health);
        //TODO: move the logic below to its own function
        if (health < 30)
        {
            //TODO: make the car turn on fire here
            var emission = particles.emission;
            emission.enabled = true;
        }

        if (health < 0)
        {
            if (player != null)
            {
                //The player should take damage here, but that function is not implemented
                playerStats.health = -1;
                GetComponent<CarMovement>().enabled = false;
            }
        }
    }
}
