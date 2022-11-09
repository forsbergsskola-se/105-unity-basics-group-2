using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject focus;
    private Vector3 velocity;

    public int cameraHeight;
    // Start is called before the first frame update
    void Start()
    {
        //In the beginning the camera should follow the player
        focus = FindObjectOfType<PlayerMovement>().gameObject;;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = focus.transform.position;
        playerPosition.y += cameraHeight;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, 0.2f);
    }

    public void NewFocus(GameObject newFocus)
    {
        focus = newFocus;
    }
}
