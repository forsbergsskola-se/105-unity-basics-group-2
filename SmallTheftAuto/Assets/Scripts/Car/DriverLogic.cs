using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverLogic : MonoBehaviour
{
    public float searchRadius;
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
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, searchRadius);
            foreach (var hitCollider in nearbyColliders)
            {
                //We just take the first car unity gives us
                //Maybe we could look for which is the closest one, but eeeehhhh.....
                if (hitCollider.gameObject.GetComponent(typeof(CarLogic)) is CarLogic)
                {
                    car = hitCollider.gameObject;
                    car.GetComponent<CarLogic>().EnterCar(this.gameObject);
                    break;
                }
            }
        }
    }
}
