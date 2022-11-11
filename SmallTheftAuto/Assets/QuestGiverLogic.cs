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
            Vector3[] vectors = new Vector3[3];
            vectors[0] = new Vector3(-3.7f,0.5f,23.5f);
            vectors[1] = new Vector3(-3f,0.5f,-21.73f);
            vectors[2] = new Vector3(-32.6f,0.5f,-1.2f);
            questStarted = true;
            objectivesFinished = new List<bool>();
            this.questTaker = questTaker;
            GameObject questObject = null;
            for (int i = 0; i < 3; i++)
            {
                questObject = Instantiate(prefab, vectors[i], Quaternion.identity);
                questObject.GetComponent<IQuestObject>().Initiate(this, i);
                objectivesFinished.Add(false);
            }
            questObject?.transform.Rotate(0,90,0);

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
