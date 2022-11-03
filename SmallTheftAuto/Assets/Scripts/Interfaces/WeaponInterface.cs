using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    interface IWeapon
    {
        float range { get; set; }
        float reloadTime { get; set; }
        float timeBetweenShots { get; set; }
        
        int magSize { get; set; }
        
        bool semiAuto { get; set; }
        
        Mesh visualMesh { get; set; }
    }

    interface IWeaponUser
    {
        void PickUpWeapon(IWeapon weapon);

        void SwitchWeapon(IWeapon weapon);
    }
}