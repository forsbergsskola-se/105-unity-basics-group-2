using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterCar(GameObject player)
    {
        this.player = player;
        GetComponent<CarMovement>().enabled = true;
        player.SetActive(false);
    }

    public void ExitCar()
    {
        GetComponent<CarMovement>().enabled = false;
        player.transform.position = transform.right; //Might be problematic in the future
        player.SetActive(true);
    }
}
