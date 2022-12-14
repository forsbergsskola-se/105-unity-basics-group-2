using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkpointLogic : MonoBehaviour, IQuestObject
{
    private int ID;

    private IQuestgiver giver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Initialise(IQuestgiver giver, int ID)
    {
        this.ID = ID;
        this.giver = giver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("something entered the trigger, it is " + other.gameObject.transform.parent.gameObject.name);
        Debug.Log("something entered the trigger, it is " + other.gameObject.name);
        //This is an awful way of doing this
        if (other.transform != null)
        {
            if (other.gameObject.name == "Player")
            {
                giver.sectionCompleted(ID);
                Debug.Log("Section finished");
                Destroy(this.gameObject);
            }
            else if (!other.gameObject.GetComponent<CarLogic>().IsUnityNull())
            {
                if (other.gameObject.GetComponent<CarLogic>().player != null)
                {
                    giver.sectionCompleted(ID);
                    Debug.Log("Section finished");
                    Destroy(this.gameObject);
                }
            }
        }
        /*if (other.gameObject.GetComponentInParent<PlayerMovement>().name == "PlayerMovement")
        {
            giver.sectionCompleted(ID);
        }*/
    }

    public void Initiate(IQuestgiver giver, int ID)
    {
        this.ID = ID;
        this.giver = giver;
    }
}
