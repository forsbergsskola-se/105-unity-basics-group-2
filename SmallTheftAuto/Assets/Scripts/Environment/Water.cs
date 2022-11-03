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

    private void OnCollisionEnter()
    {
        health = 0;
        player.GetComponent<Death>().OnDeath();
    }
}
