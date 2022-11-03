using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
   private int health;
   public PlayerStats playerStats;

   private void Start()
   {
      health = playerStats.health;
   }

   public void OnDeath()
   {
      Debug.Log("Called OnDeath.");
      if (health <= 0)
      {
         Debug.Log("You are dead.");
      }
   }
}
