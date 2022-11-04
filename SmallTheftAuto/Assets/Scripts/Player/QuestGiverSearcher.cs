using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverSearcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, 10.0f);
            foreach (var hitCollider in nearbyColliders)
            {
                Debug.Log("Looking for quest givers");
                if (hitCollider.gameObject.GetComponent(typeof(QuestLogic)) is QuestLogic)
                {
                    Debug.Log("We found one");
                    GameObject target = hitCollider.gameObject;
                    target.SendMessage("activateQuest");
                    break;
                }
            }
        }
    }
}
