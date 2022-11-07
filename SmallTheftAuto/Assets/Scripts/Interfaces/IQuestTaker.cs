using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestTaker
{
    void RecieveReward(int money, int points);
}

public interface IQuestgiver
{
    void sectionCompleted(int ID);
}

public interface IQuestObject
{
    void Initiate(IQuestgiver giver, int ID);

}
