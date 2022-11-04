using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogic : MonoBehaviour
{
    private IQuestTaker questTaker;
    private List<bool> objectivesFinished;

    private int moneyReward;
    private int pointsReward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This row could be integrated into the if statement below but I want it here for readability
        bool allFinished = objectivesFinished.TrueForAll( b => b);
        if (allFinished)
        {
            questTaker.RecieveReward(moneyReward, pointsReward);
            //TODO: display some sort of quest complete UI element
        }
    }

    public void activateQuest(QuestTaker questTaker)
    {
        Debug.Log("Quest activated!");
        this.questTaker = questTaker;
    }

    private void CreateQuest()
    {
        //TODO: spawn quest objects here
    }
    
    
}
