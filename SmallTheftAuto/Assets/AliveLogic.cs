using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveLogic : MonoBehaviour
{
    
    public delegate void OnPlayerDeath();

    public event OnPlayerDeath PlayerDied;

    public PlayerStats PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.money = 0;
        PlayerStats.score = 0;
        PlayerStats.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.health <= 0)
        {
            PlayerDied?.Invoke();
            
            StartCoroutine(respawnRoutine());
        }
    }
    IEnumerator respawnRoutine()
    {
        GetComponentInChildren<MeshRenderer>().enabled = false;
        //GetComponent<MeshRenderer>().enabled = false;
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        //gameObject.SetActive(true);
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = true;
        PlayerStats.health = 100;
        PlayerStats.money /= 2;
        transform.position = new Vector3(0, 1, 0);

    }
}
