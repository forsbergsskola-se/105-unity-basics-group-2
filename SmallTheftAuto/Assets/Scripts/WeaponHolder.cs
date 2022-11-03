using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponHolder : MonoBehaviour
{
    public Weapon heldWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        heldWeapon = Resources.Load<Weapon>("Pistol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
