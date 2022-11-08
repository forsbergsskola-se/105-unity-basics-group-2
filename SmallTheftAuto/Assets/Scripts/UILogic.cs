using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text pointsText;
    public TMP_Text moneyText;
    public TMP_Text deathText;
    public TMP_Text questStartText;
    public GameObject questImage;

    public PlayerStats PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        deathText.enabled = false;
        questStartText.enabled = false;
        questImage.SetActive(false);
        QuestGiverLogic questGiver = FindObjectOfType<QuestGiverLogic>();
        questGiver.QuestStarted += showQuestInstruction;
        AliveLogic aliveLogic = FindObjectOfType<AliveLogic>();
        aliveLogic.PlayerDied += WastedScreen;
    }   

    // Update is called once per frame
    void Update()
    {
        healthText.SetText("Health: " + PlayerStats.health);
        pointsText.SetText("Points: " + PlayerStats.score);
        moneyText.SetText("Money: " + PlayerStats.money);
        
        
    }

    public void showQuestInstruction()
    {
        StartCoroutine(TemporaryQuestPopUp());
        Debug.Log("The event worked");
    }
    IEnumerator TemporaryQuestPopUp()
    {
        questImage.SetActive(true);
        questStartText.enabled = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        questImage.SetActive(false);
        questStartText.enabled = false;

    }

    public void WastedScreen()//Is writing a function just for this really necessary? But Im too lazy to try without it....
    {
        StartCoroutine(WastedPopup());
    }
    
    IEnumerator WastedPopup()
    {
        healthText.enabled = false;
        pointsText.enabled = false;
        moneyText.enabled = false;
        deathText.enabled = true;
        yield return new WaitForSeconds(5);
        healthText.enabled = true;
        pointsText.enabled = true;
        moneyText.enabled = true;
        deathText.enabled = false;

    }
    
}
