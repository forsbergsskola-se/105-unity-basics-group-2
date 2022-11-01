using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    public bool hasCar;
    private bool willSpawnNewCar = false;

    public GameObject carPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (hasCar)
        {
            var transform1 = transform;
            Vector3 carPosition = transform1.position;
            carPosition.y += 5;
            Instantiate(carPrefab, carPosition, transform1.rotation);
        }
        //OnCollisionExit(new Collision());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        //Checking the object name like this feels like it could easily break, but I cant think of a better solution rn
        if (other.gameObject.name == "Car(Clone)" && !willSpawnNewCar)
        {
            willSpawnNewCar = true;
            StartCoroutine(WaitBeforeSpawning());
        }
    }

    private IEnumerator WaitBeforeSpawning()
    {
        yield return new WaitForSeconds(10);
        Start(); //Run start to spawn a new car, this way we also check if hasCar still is true
        willSpawnNewCar = false;
    }
    
}
