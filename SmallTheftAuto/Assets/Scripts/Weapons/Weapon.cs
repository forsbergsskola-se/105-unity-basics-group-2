using Interfaces;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu]
    public class Weapon : ScriptableObject
    {
        public float range;
        public float reloadTime;
        public float timeBetweenShots;
        public int magSize;
        public bool semiAuto;
        public Mesh visualMesh;
    }
}