using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject player;
    private int health;
    public PlayerStats playerStats;

    private void Start()
    {
        health = playerStats.health;
    }

     void OnTriggerEnter(Collider other)
     {
         Drowning drowning = other.GetComponent<Drowning>();
         if (drowning == null)
         {
             other.gameObject.AddComponent<Drowning>();
         }
        
    }
    
}
