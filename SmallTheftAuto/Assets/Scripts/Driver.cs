using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    void Update()
    {
        if (IsEnterCarPressed())
        {
            Vehicle[] vehicles = FindObjectsOfType<Vehicle>();
            Vehicle closestCar = FindclosestVehicle(vehicles);
            
            if(Vector3.Distance(transform.position, closestCar.transform.position)<2)
            {
                closestCar.EnterCar(gameObject);
                
            }

        }
    }

    Vehicle FindclosestVehicle(Vehicle[] vehicles)
    {
        Vehicle closestCar = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        for (var i = 0; i < vehicles.Length; i++)
        {
            Vehicle vehicle = vehicles[i];
            float distance = Vector3.Distance(currentPos, vehicle.transform.position);
            if (distance < minDist)
            {
                closestCar = vehicle;
                minDist = distance;
            }
        }
        return closestCar;
    }
    
    public bool IsEnterCarPressed()
    {
        return Input.GetButtonUp("Interact-Vehicle");
        
    }
}
