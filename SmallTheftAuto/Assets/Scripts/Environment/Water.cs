using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    public PlayerStats playerStats;

  

     void OnTriggerStay(Collider other)
     {
         Debug.Log("Player in water.");
         playerStats.health = 0;

     }
    
}
