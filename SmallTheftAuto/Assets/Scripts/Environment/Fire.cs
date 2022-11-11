using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float timeUntilExtinguish;
    private float timeSinceStart;

    private void Awake()
    {
        timeUntilExtinguish = 20;
        timeSinceStart = 0;
    }

    void Update()
    {
        if (timeSinceStart < timeUntilExtinguish)
        {
            timeSinceStart += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            Burning burning = other.GetComponent<Burning>();
            if (burning.enabled == false)
            {
                burning.enabled = true;
            }
        }
    }
}
