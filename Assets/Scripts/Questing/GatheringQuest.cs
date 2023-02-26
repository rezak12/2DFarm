using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GatheringQuest : Quest
{
    public GatheringQuest(string questName, List<QuestGoal> goals, int xpReward) : base(questName, goals, xpReward)
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
