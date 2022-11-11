using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerup : MonoBehaviour
{
    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        playerStats.health += 20;
        Destroy(gameObject);
    }
}
