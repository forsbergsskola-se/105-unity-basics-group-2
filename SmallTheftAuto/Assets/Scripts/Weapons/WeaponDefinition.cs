using UnityEngine;

[CreateAssetMenu]
public class WeaponDefinition : ScriptableObject
{
    public float range;
    public float reloadTime;
    public float timeBetweenShots;
    public int magSize;
    public bool semiAuto;
    public bool usesBullets;
    
    public GameObject WeaponVisual;
    public Vector3 PlayerOffset;

    public float maxInaccuracyDegreesVertical;
    public float maxInaccuracyDegreesHorizontal;
}
