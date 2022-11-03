using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;



public class Old_Pistol : MonoBehaviour, IWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float range { get; set; }
    public float reloadTime { get; set; }
    public float timeBetweenShots { get; set; }
    public int magSize { get; set; }
    public bool semiAuto { get; set; }
    public Mesh visualMesh { get; set; }
}
