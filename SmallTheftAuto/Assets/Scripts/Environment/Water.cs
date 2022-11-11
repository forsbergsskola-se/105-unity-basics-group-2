using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    public PlayerStats playerStats;

  

     void OnTriggerStay(Collider other)
     {
         playerStats.health = 0;
     }
    
}
