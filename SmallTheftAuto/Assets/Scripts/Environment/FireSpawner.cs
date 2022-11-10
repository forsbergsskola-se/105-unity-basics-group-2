using UnityEngine;
using Random = UnityEngine.Random;

public class FireSpawner : MonoBehaviour
{
   public GameObject firePrefab;
   private void OnEnable()
   {
       int FireAmount = Random.Range(1, 5);
       Debug.Log($"{FireAmount}");
       for (int i = 0; i < FireAmount; i++)
       {
           int randomXOffset = Random.Range(-2, 2);
           int randomZOffset = Random.Range(-2, 2);
           Instantiate(firePrefab, new Vector3(transform.position.x + randomXOffset, transform.position.y, transform.position.z + randomZOffset),Quaternion.Euler(
               0, 0, 0));
       }
   }
}
