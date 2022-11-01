using UnityEngine;

public class Driver : MonoBehaviour
{
    private Vehicle _closestCar;
    void Update()
    {
        if (EnterCarButtonPressed())
        {
            Vehicle[] vehicles = FindObjectsOfType<Vehicle>();
            _closestCar = FindClosestVehicle(vehicles);
            if (Vector3.Distance(transform.position, _closestCar.transform.position) < 3)
            {
                _closestCar.EnterCar(gameObject);
            }
        }
    }

    Vehicle FindClosestVehicle(Vehicle[] vehicles)
    {
        Vehicle closestCar = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        for (var i = 0; i < vehicles.Length; i++)
        {
            Vehicle vehicle = vehicles[i];
            float distance = Vector3.Distance(currentPos, vehicle.transform.position);
            if (distance < minDistance)
            {
                closestCar = vehicle;
                minDistance = distance;
            }
        }
        return closestCar;
    }

    public bool EnterCarButtonPressed()
    {
        return Input.GetButtonDown("Interact-Vehicle");
    }
}
