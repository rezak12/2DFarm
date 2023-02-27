using System;
using System.Collections.Generic;

[System.Serializable]
public class Quest
{
    public string QuestName { get; private set; }
    public List<QuestGoal> Goals { get; private set; }
    public bool isCompleted { get; private set; }
    public int XPReward { get; private set; }

    public Action<ExperinceSystem> OnComplete;

    public Quest(string questName, List<QuestGoal> goals, int xpReward)
    {
        this.QuestName = questName;
        this.Goals = goals;
        this.isCompleted = false;
        this.XPReward = xpReward;
        this.OnComplete += TakeReward;
    }

    public virtual void CheckGoal(string argument)
    {
        if(Goals.TrueForAll(g => g.IsComplete))
        {
            isCompleted = true;
        }
    }

    private void TakeReward(ExperinceSystem ex)
    {
        ex.TakeXP(XPReward);
    }
}

