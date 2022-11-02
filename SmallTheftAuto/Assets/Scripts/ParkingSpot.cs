using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    public bool hasCar;
    public GameObject carPrefab;
    
    void Start()
    {
        if (hasCar)
        {
            var position = transform.position;
            Instantiate(carPrefab, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0,0,0));
        }
    }

    
}
