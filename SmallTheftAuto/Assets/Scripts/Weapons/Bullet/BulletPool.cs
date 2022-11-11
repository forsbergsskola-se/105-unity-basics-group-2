// using System;
// using UnityEngine;
// using UnityEngine.Pool;
//
// // https://learn.unity.com/tutorial/introduction-to-object-pooling#5ff8d015edbc2a002063971d
// // https://www.gamedeveloper.com/design/object-pooling-in-unity-2021-
// // https://github.com/llamacademy/2021-object-pool/blob/main/Assets/Scripts/BulletSpawner.cs
// public class BulletPool : MonoBehaviour
// {
//     [SerializeField]
//     private ObjectPool<Bullet> bulletPool;
//
//     
//     private void Awake()
//     {
//         bulletPool = new ObjectPool<Bullet>(CreatePooledInstance, );
//     }
//
//     Bullet CreatePooledInstance()
//     {
//         var pooledBulletInst = new GameObject("Bullet", Bullet.BulletComponents);
//         
//     }
// }
