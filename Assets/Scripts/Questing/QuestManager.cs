using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Queue<Quest> quests = new Queue<Quest>();
    public Quest currentQuest { get; private set; }
    void Start()
    {
        //GatheringQuest quest = new GatheringQuest("Halloween", new List<QuestGoal>());
        //quest.Goals.Add(new GatheringQuestGoal("Plant 10 pumpkin", 0, 10, "pumpkin"));
        //quest.Goals.Add(new GatheringQuestGoal("Plant 5 tomato", 0, 5, "tomato"));
        //quests.Enqueue(quest); 
        //GatheringQuest quest2 = new GatheringQuest("melodyLoh", new List<QuestGoal>());
        //quest2.Goals.Add(new GatheringQuestGoal("Plant 2 turnip", 0, 2, "turnip"));
        //quest2.Goals.Add(new GatheringQuestGoal("Plant 6 strawberry", 0, 6, "strawberry"));
        //quests.Enqueue(quest2);
        //currentQuest = quests.Dequeue();
    }

    public void SetNewQuest() 
    { 
        if(quests.Count > 0)
            currentQuest = quests.Dequeue();
        else
        {
            currentQuest = null;
        }
    }

    public void TakeNewQuest(Quest quest)
    {
        quests.Enqueue(quest);
        if (currentQuest == null)
            SetNewQuest();
    }

    public void CheckChange(string argument)
    {
        if (currentQuest == null)
            return;

        currentQuest.CheckGoal(argument);
        if (currentQuest.isCompleted)
            SetNewQuest();
    }
}
