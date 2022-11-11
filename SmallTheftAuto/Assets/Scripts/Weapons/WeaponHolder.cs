using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponHolder : MonoBehaviour
{
    public Weapon heldWeapon;
    public Vector3 weaponOffset;
    
    private float heldRange;
    private float heldReloadTime;
    private float heldTimeBetweenShots;
    private int heldMagSize;
    private bool heldSemiAuto;
    private Mesh heldVisualMesh;

    private GameObject heldWeaponObject;
    
    
    void Start()
    {
        
    }

    private void Awake()
    {
        heldWeaponObject.AddComponent<MeshFilter>();
        heldWeaponObject.AddComponent<MeshRenderer>();
    }

    void SwitchWeapon(Weapon newWeapon)
    {
        heldRange = heldWeapon.range;
        heldReloadTime = heldWeapon.reloadTime;
        heldTimeBetweenShots = heldWeapon.timeBetweenShots;
        heldMagSize = heldWeapon.magSize;
        heldSemiAuto = heldWeapon.semiAuto;
        heldVisualMesh = heldWeapon.visualMesh;

        heldWeaponObject.GetComponent<MeshFilter>().mesh = heldVisualMesh;
    }
    
    void OnEnable()
    {
        SwitchWeapon( Resources.Load<Weapon>("Pistol") );
    }

    void PrimaryFire()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
