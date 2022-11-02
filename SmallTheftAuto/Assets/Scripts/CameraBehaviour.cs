using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject focus;

    public int cameraHeight;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
        focus = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = focus.transform.position;
        playerPosition.y += cameraHeight;
        transform.position = Vector3.Lerp(transform.position, playerPosition, 0.5f);
    }

    public void NewFocus(GameObject newFocus)
    {
        focus = newFocus;
    }
}
