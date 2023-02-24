using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Quest
{
    public string QuestName { get; private set; }
    public List<QuestGoal> Goals { get; private set; }
    public bool isActive { get; private set; }
    public bool isCompleted { get; private set; }

    public Quest(string questName, List<QuestGoal> goals)
    {
        this.QuestName = questName;
        this.Goals = goals;
        this.isActive = false;
        this.isCompleted = false;
    }

    public virtual void CheckGoal(string argument)
    {
        if(Goals.TrueForAll(g => g.IsComplete))
            isCompleted = true;
    }
}

