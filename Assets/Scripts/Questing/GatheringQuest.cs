using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GatheringQuest : Quest
{
    public GatheringQuest(string questName, List<QuestGoal> goals) : base(questName, goals)
    {
    }

    public override void CheckGoal(string argument)
    {
        foreach (GatheringQuestGoal goal in Goals)
        {
            if(argument == goal.PlantName)
            {
                goal.ChangeCurrentAmount(argument);
            }
        }
        base.CheckGoal(argument);
    }
}
