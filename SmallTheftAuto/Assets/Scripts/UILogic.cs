using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text pointsText;
    public TMP_Text moneyText;
    public TMP_Text deathText;

    public PlayerStats PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        deathText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText("Health: " + PlayerStats.health);
        pointsText.SetText("Points: " + PlayerStats.score);
        moneyText.SetText("Money: " + PlayerStats.money);
        if (PlayerStats.health <= 0)
        {
            healthText.enabled = false;
            pointsText.enabled = false;
            moneyText.enabled = false;
            deathText.enabled = true;
        }
        
    }
}
