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
            questStarted = true;
            objectivesFinished = new List<bool>();
            this.questTaker = questTaker;
            for (int i = 0; i < 3; i++)
            {
                Vector3 position = new Vector3();
                System.Random random = new System.Random();
                position.x = random.Next(-10, 11);
                position.z = random.Next(-10, 11);
                position.y = 0.5f;
                GameObject questObject = Instantiate(prefab, position, Quaternion.identity);
                questObject.GetComponent<IQuestObject>().Initiate(this, i);
                objectivesFinished.Add(false);
            }
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
