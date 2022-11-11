using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    public PlayerStats playerStats;
    private float timeSinceDamage;
    private float timeBetweenDamage;
    private float timeUntilExtinguish;
    private float timeSinceEnabled;
    private int burningDamage;

    private void Awake()
    {
        timeSinceDamage = 0;
        timeBetweenDamage = 1;
        burningDamage = 5;
        timeUntilExtinguish = 5;
        timeSinceEnabled = 0;
    }

    private void FixedUpdate()
    {
        if (timeSinceDamage < timeBetweenDamage)
        {
            timeSinceDamage += Time.deltaTime;
        }
        else
        {
            playerStats.TakeDamage(burningDamage);
            Debug.Log($"Takes {burningDamage} damage.");
            timeSinceDamage = 0;
        }

        if (timeSinceEnabled < timeUntilExtinguish)
            timeSinceEnabled += Time.deltaTime;
        else
        {
            timeSinceEnabled = 0;
            gameObject.GetComponent<Burning>().enabled = false;
        }
    }


}