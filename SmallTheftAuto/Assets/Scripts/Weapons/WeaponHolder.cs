using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoState
{
    public int ammoLoaded;
    public int ammoReserve;

    public AmmoState()
    {
    }
    
    public AmmoState(int ammoLoaded, int ammoReserve)
    {
        this.ammoLoaded = ammoLoaded;
        this.ammoReserve = ammoReserve;
    }
};

public class WeaponHolder : MonoBehaviour
{
    public Weapon curWeapon;
    
    // Maybe Todo: Move these to weapon definition (scriptable object)
    public Vector3 weaponOffset;
    public float InaccuracyPerShotFactor = 0.1f;
    public float InaccuracyRecoverPerSecond = 0.1f;
    
    public bool useAmmo; // Infinite ammo when false
    public bool defaultIsLoaded; // first time equip - clip full?
    public int defaultReserveAmmo = 16; // first time equip - how much in reserve?

    // singleton patterned weaponIndex
    private static WeaponIndex _weaponIndex;

    // object that also appears in the game world
    private GameObject curWeaponWorld;

    private MeshFilter curWeaponWorldMeshFilter;
    private MeshRenderer curWeaponWorldMeshRenderer;
    
    // for weapon logic
    
    // todo: maybe explain to group?
    public Dictionary<Weapon, AmmoState> PerWeaponAmmoState; // ScriptableObject equivalence could be a source of bugs
    private AmmoState curAmmoState;

    private float lastFire;
    private float nextFire; // time when you can fire your next round


    private void Awake()
    {
        curWeaponWorld = new GameObject();
        curWeaponWorld.transform.localPosition = weaponOffset;
        
        curWeaponWorldMeshFilter   = curWeaponWorld.AddComponent<MeshFilter>();
        curWeaponWorldMeshRenderer = curWeaponWorld.AddComponent<MeshRenderer>();
        
        if (_weaponIndex == null)
        {
            _weaponIndex = curWeaponWorld.AddComponent<WeaponIndex>();
        }
    }

    // Gets an AmmoState if it is stored in PerWeaponAmmoState
    // Otherwise, create one using
    // Then stores it in PerWeaponAmmoState
   private AmmoState GetOrCreateAmmoState(Weapon weapon)
    {
        // If we already have a stored AmmoState, 
        // var here means 'assign it to a new variable'
        if (!PerWeaponAmmoState.TryGetValue(weapon, out var retAmmoState))
        {
            // no ammo state for the weapon in PerWeaponAmmoState,
            // first time using a weapon logic (for this GameObject/Component)
            // construct a new AmmoState
            int ammoLoaded = (defaultIsLoaded ? weapon.magSize : 0);
            int ammoReserve = defaultReserveAmmo;
            retAmmoState = new AmmoState(ammoLoaded, ammoReserve);
        }
        PerWeaponAmmoState[weapon] = retAmmoState; // and store it
        return retAmmoState;
    }
    
   // reset ammo information
   // todo: useful probably on death
   public void ClearAmmoStates() => PerWeaponAmmoState.Clear();
   
    void SwitchWeapon(Weapon newWeapon)
    {
        if (curWeapon == newWeapon)
        {
            // @ means verbatim string, stores the newline.
            Debug.Log(@"Cannot switch to the same weapon you're already holding
            Ignoring Weapon Switch...");
            return;
        }

        curAmmoState = GetOrCreateAmmoState(newWeapon);

        curWeapon = newWeapon; // update our scriptable object asset reference
        curWeaponWorldMeshFilter.mesh = curWeapon.visualMesh;
    }

    void OnEnable()
    {
        SwitchWeapon( WeaponIndex.Pistol );
    }
    
    Vector3 GetFireVector()
    {
        Vector3 forwardVec = curWeaponWorld.transform.forward;
        return forwardVec;
    }

    void FireBullet(Vector3 fireVector)
    {
        Instantiate();
    }
    
    void PrimaryFire()
    {
        float curTime = Time.time;
        
        if (curTime > nextFire)
        {
            ()    
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
