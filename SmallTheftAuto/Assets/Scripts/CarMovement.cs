using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 40f;
    private Driver driver;
    void Update()
    {
        // only, if the W-Key is currently pressed...
        float movement = Input.GetAxis ("Vertical"); 
        // translate the player's transform-component on the y-axis (which points up)
        transform.Translate(0f, movementSpeed * movement * Time.deltaTime, 0f);

        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0f,0f,-rotationSpeed * rotation * Time.deltaTime);

        driver = FindObjectOfType<Driver>();
        Vehicle vehicle = FindObjectOfType<Vehicle>();
        if (driver.EnterCarButtonPressed())
        {
            if (PlayerIsInCar())
            {
                vehicle.LeaveCar();
            }
        }
    }
    
    public bool PlayerIsInCar()
    {
        return !activeInHierarchy;
    }
}