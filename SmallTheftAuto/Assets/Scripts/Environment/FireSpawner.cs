using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
   public GameObject firePrefab;
   private void Start()
   {
      Instantiate(firePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.Euler(
         0, 0, 0));
   }
}
