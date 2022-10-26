using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCounter : MonoBehaviour
{
    private int brickCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountBrick()
    {
        brickCount++;
        Debug.Log($"Total Bricks Removed: {brickCount}");
    }
}
