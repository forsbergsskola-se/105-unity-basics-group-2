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
        gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        gameObject.SetActive(true);
        PlayerStats.health = 100;
        PlayerStats.money /= 2;

    }
}
