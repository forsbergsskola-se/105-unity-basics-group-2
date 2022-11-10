using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverLogic : MonoBehaviour, IQuestgiver
{

    public delegate void OnQuestStart();
    public event OnQuestStart QuestStarted;
    private IQuestTaker questTaker;
    private List<bool> objectivesFinished;
    public GameObject prefab;

    private bool questStarted = false;

    private int moneyReward;
    private int pointsReward;
    // Start is called before the first frame update
    void Start()
    {
        moneyReward = 200;
        pointsReward = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkIfAllFinished()
    {
        //This row could be integrated into the if statement below but I want it here for readability
        bool allFinished = objectivesFinished.TrueForAll( b => b);
        if (allFinished)
        {
            questTaker.RecieveReward(moneyReward, pointsReward);
            questStarted = false;
        }
    }

    public void activateQuest(IQuestTaker questTaker)
    {
        if (!questStarted)
        {
            
            //This is a bunch of repetetive code that could probably be in a loop but my brain is too smooth to 
            //make that happen
            questStarted = true;
            objectivesFinished = new List<bool>();
            this.questTaker = questTaker;
            Vector3 position = new Vector3(-3.7f,0.5f,23.5f);
            GameObject questObject = Instantiate(prefab, position, Quaternion.identity);
            questObject.GetComponent<IQuestObject>().Initiate(this, 0);
            position = new Vector3(-3f,0.5f,-21.73f);
            questObject = Instantiate(prefab, position, Quaternion.identity);
            questObject.GetComponent<IQuestObject>().Initiate(this, 1);
            position = new Vector3(-32.6f,0.5f,-1.2f);
            questObject = Instantiate(prefab, position, Quaternion.identity);
            questObject.transform.Rotate(0,90,0);
            questObject.GetComponent<IQuestObject>().Initiate(this, 2);
            
            objectivesFinished.Add(false);
            objectivesFinished.Add(false);
            objectivesFinished.Add(false);
            
            QuestStarted?.Invoke();
        }
    }

    private void CreateQuest()
    {
        
    }


    public void sectionCompleted(int ID)
    {
        objectivesFinished[ID] = true;
        checkIfAllFinished();
    }
}
