using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drowning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            Death death = GetComponent<Death>();
            if (death == null)
            {
                gameObject.AddComponent<Death>();
            }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
