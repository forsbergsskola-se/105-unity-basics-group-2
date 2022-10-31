using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    public bool hasCar;

    public GameObject carPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (hasCar)
        {
            Vector3 carPosition = transform.position;
            carPosition.y += 2;
            Instantiate(carPrefab, carPosition, transform.rotation);
        }
        OnCollisionExit(new Collision());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (true)
        {
            test();
        }
    }

    IEnumerator test()
    {
        Debug.Log("hello");
        yield return new WaitForSeconds(5);
        
        Debug.Log("hello again");
    }
    
}
