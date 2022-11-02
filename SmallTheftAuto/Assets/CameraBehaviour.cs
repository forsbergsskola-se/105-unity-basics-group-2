using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject player;

    public int cameraHeight;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y += cameraHeight;
        transform.position = Vector3.Lerp(transform.position, playerPosition, 0.5f);
    }
}
