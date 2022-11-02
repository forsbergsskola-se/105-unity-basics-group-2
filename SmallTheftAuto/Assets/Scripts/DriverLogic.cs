using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLogic : MonoBehaviour
{
    private GameObject car; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, 10.0f);
            foreach (var hitCollider in nearbyColliders)
            {
                Debug.Log("Looking for cars");
                if (hitCollider.gameObject.GetComponent(typeof(CarLogic)) is CarLogic)
                {
                    Debug.Log("We found one");
                    car = hitCollider.gameObject;
                    car.GetComponent<CarLogic>().EnterCar(this.gameObject);
                    break;
                }
            }
        }
    }
}
