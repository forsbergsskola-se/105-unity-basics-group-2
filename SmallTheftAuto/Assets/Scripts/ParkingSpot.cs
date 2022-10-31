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
            Instantiate(carPrefab, new Vector3(-40f, -15f, -12), Quaternion.Euler(0,0,0));
            hasCar = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
