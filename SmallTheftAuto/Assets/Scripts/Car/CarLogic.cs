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
    public GameObject player;

    private GameObject mainCamera;

    private GameObject fire;

    private bool hasBurned = false;

    private float maxHealth;
    // private ParticleSystem particles;
    public PlayerStats playerStats;
    public float exitOffset;
    public float health;

    private bool isCarDead;

    void Start()
    {
        fire = GetComponentInChildren<ParticleSystem>().gameObject;
        fire.SetActive(false);
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.health <= 0)
        {
            ExitCar();
        }
    }
    public void EnterCar(GameObject player)
    {
        if (health > 0)
        {
            this.player = player;
            //We need to do a bunch of stuff here to check if the camera we found is actually the main camera and
            //not the minimap camera 
            Camera[] cameras = FindObjectsOfType<Camera>();
            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i].gameObject.GetComponent<CameraBehaviour>() != null)
                {
                    mainCamera = cameras[i].gameObject;
                    break;
                }
            }
            //mainCamera = GetComponent<Camera>().gameObject;
            mainCamera.GetComponent<CameraBehaviour>().NewFocus(gameObject);
            GetComponent<CarMovement>().enabled = true;
            player.SetActive(false);
        }
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
        /*Debug.Log(collision.gameObject.GetComponent<Water>());
        if (collision.gameObject.GetComponent<Water>() != null)
        {
            ExitCar();
        }*/
        if (collision.relativeVelocity.magnitude > 15f)
        {
            health -= collision.relativeVelocity.magnitude;
            Debug.Log("Magnitude was high enough");
        }
        Debug.Log("velocity magnitude was: " + collision.relativeVelocity.magnitude);
        Debug.Log("New car health is: " + health);
        //TODO: move the logic below to its own function
        if (health < (maxHealth / 4) && !hasBurned)
        {
            fire.SetActive(true);
        }

        if (health < 0 && isCarDead == false)
        {
            isCarDead = true;
            GetComponent<FireSpawner>().enabled = true;
            if (player != null)
            {
                ExitCar();
                playerStats.health = -1;
                GetComponent<CarMovement>().enabled = false;
            }

            if (!hasBurned)
            {
                hasBurned = true;
                StartCoroutine(WaitForFireToBurnOut());
                GetComponent<FireSpawner>().enabled = false;
            }
        }
    }
    IEnumerator WaitForFireToBurnOut()
    {
        yield return new WaitForSeconds(20);
        fire.SetActive(false);
    }
}
