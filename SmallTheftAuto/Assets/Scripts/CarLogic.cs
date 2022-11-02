using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private GameObject camera;
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
        camera = GameObject.Find("Main Camera");
        camera.GetComponent<CameraBehaviour>().NewFocus(gameObject);
        GetComponent<CarMovement>().enabled = true;
        player.SetActive(false);
    }

    public void ExitCar()
    {
        GetComponent<CarMovement>().enabled = false;
        player.transform.position = transform.right; //Might be problematic in the future
        camera.GetComponent<CameraBehaviour>().NewFocus(player);
        player.SetActive(true);
    }
}
