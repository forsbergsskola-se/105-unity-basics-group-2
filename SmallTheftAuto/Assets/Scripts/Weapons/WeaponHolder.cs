using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private WeaponDefinition curWeaponDefinition;
    
    // Maybe Todo: Move these to weaponDefinition definition (scriptable object)
    public float fireBulletOffset; // vec.x away from the bounding box
    [SerializeField]
    public GameObject bulletObject;
    public float inaccuracyPerShotFactor = 0.1f;
    public float inaccuracyRecoverPerSecond = 0.1f;
    
    public bool useAmmo; // Infinite ammo when false
    public bool defaultIsLoaded; // first time equip - clip full?
    public int defaultReserveAmmo = 16; // first time equip - how much in reserve?

    [SerializeField]
    public WeaponDefinition wepDefHands;
    [SerializeField]
    public WeaponDefinition wepDefPistol;
    [SerializeField]
    public WeaponDefinition wepDefMachineGun;
    
    // empty that gets parented to the player + has functionality
    private GameObject curWeaponEmpty;
    private GameObject curWeaponWorldVisuals; // prefab that just gets displayed in the world

    // for weaponDefinition logic
    
    // todo: maybe explain to group?
    public Dictionary<string, AmmoState> PerWeaponAmmoState;
    private AmmoState curAmmoState;

    private float lastFire; 
    private float nextFire; // time when you can fire your next round
    
    private float curInaccuracyFactor; // 0f to 1f - grows when firing
    private float fireAngVariationHori; // Updated on weapon switch, half of total horizontal
    private float fireAngVariationVert;   // half of total vertical
    
    private void Awake()
    {
        // Create empty named "Weapon" and parent it to script parent
        curWeaponEmpty = new GameObject("Weapon");
        curWeaponEmpty.transform.SetParent(gameObject.transform, false);
        // curWeaponEmpty.transform.parent = gameObject.transform;
        // curWeaponEmpty.transform.localPosition = Vector3.zero;

        PerWeaponAmmoState = new Dictionary<string, AmmoState>();
    }

    // Gets an AmmoState if it is stored in PerWeaponAmmoState
    // Otherwise, create one using
    // Then stores it in PerWeaponAmmoState
   private AmmoState GetOrCreateAmmoState(WeaponDefinition weaponDefinition)
   {
       Debug.Assert(weaponDefinition != null);
       
        // If we already have a stored AmmoState, 
        // var here means 'assign it to a new variable'
        if (!PerWeaponAmmoState.TryGetValue(weaponDefinition.name, out var retAmmoState))
        {
            // no ammo state for the weaponDefinition in PerWeaponAmmoState,
            // first time using a weaponDefinition logic (for this GameObject/Component)
            // construct a new AmmoState
            int ammoLoaded = (defaultIsLoaded ? weaponDefinition.magSize : 0);
            int ammoReserve = defaultReserveAmmo;
            retAmmoState = new AmmoState(ammoLoaded, ammoReserve);
        }
        PerWeaponAmmoState[weaponDefinition.name] = retAmmoState; // and store it
        return retAmmoState;
    }
    
   // reset ammo information
   // todo: useful probably on death
   public void ClearAmmoStates() => PerWeaponAmmoState.Clear();
   
   // destroys old world visual, replaces it with a new GameObject and returns the new one
    GameObject ReplaceWeaponVisuals(WeaponDefinition newWeapon)
    {
        Destroy(curWeaponWorldVisuals); // There are many better ways but w/e

        GameObject newVisuals = newWeapon.WeaponVisual;
        Vector3    newVisualOffset = newWeapon.PlayerOffset;
        Quaternion newVisualRot = Quaternion.identity;
        Transform parentTransform = curWeaponEmpty.transform;

        GameObject newWorldVisual = Instantiate(newVisuals, newVisualOffset, newVisualRot);
        newWorldVisual.transform.SetParent(parentTransform, false);
        newWorldVisual.transform.localPosition = newVisualOffset;

        return newWorldVisual;
    }
   
    private void CacheInnaccuracyVariance(WeaponDefinition weaponDef)
    {
        fireAngVariationVert = weaponDef.maxInaccuracyDegreesVertical * 0.5f;
        fireAngVariationHori = weaponDef.maxInaccuracyDegreesHorizontal * 0.5f;
    }
    
    void SwitchWeapon(WeaponDefinition newWeaponDefinition)
    {
        if (curWeaponDefinition != null)
        {
            if (curWeaponDefinition.name == newWeaponDefinition.name)
            {
                Debug.Log($"Held Weapon: {curWeaponDefinition}, new Weapon: {newWeaponDefinition}");

                Debug.Log("Cannot switch to the same weaponDefinition you're already holding, ignoring WeaponDefinition Switch...");
                return;
            }
        }
        
        curAmmoState = GetOrCreateAmmoState(newWeaponDefinition);
        curWeaponWorldVisuals = ReplaceWeaponVisuals(newWeaponDefinition);
        CacheInnaccuracyVariance(newWeaponDefinition);

        curWeaponDefinition = newWeaponDefinition; // update our scriptable object asset reference
    }

    void OnEnable()
    {
        SwitchWeapon( wepDefPistol );
    }
    
    Quaternion GetFiringAngle()
    {
        float inaccuracyAngRandHori = Random.Range( -fireAngVariationHori, fireAngVariationHori ); // not equal in both fireAngle but close enough
        float inaccuracyAngRandVert = Random.Range( -fireAngVariationVert, fireAngVariationVert ); // not equal in both fireAngle but close enough

        float firingAngleHori = inaccuracyAngRandHori * curInaccuracyFactor;
        float firingAngleVert = inaccuracyAngRandVert * curInaccuracyFactor;

        Quaternion firingAngle = new Quaternion(0, firingAngleHori, firingAngleVert, 1);

        return firingAngle;
    }

    void FireBullet(Vector3 startPosFromGun, Quaternion fireAngle)
    {
        Vector3 fireFrom = curWeaponEmpty.transform.position; //+ startPosFromGun; - may be needed if InstansiateInWorldSpace
// wont work?
        var create = (GameObject)Instantiate(bulletObject, fireFrom, fireAngle);
    }
    
    void PrimaryFire()
    {
        float curTime = Time.time;
        
        if (curTime > nextFire)
        {
            FireBullet( curWeaponDefinition.GunFireOffset, GetFiringAngle() );
            // TODO: Inaccuracy factor increment
            // FireBullet(GetFiringAngle());
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // TODO: REPLACE!!!!!
        // TODO: REPLACE!!!!!
        if (Input.GetKeyDown("space"))
        {
            PrimaryFire();
        }
    }
}
