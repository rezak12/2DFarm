[System.Serializable]
public class QuestGoal
{
    public string GoalName { get; private set; }
    public int CurrentAmount { get; private set; }
    public int RequirementAmount { get; private set; }
    public bool IsComplete { get; private set; }

    public QuestGoal(string goalName, int currentAmount, int requirementAmount)
    {
        GoalName = goalName;
        CurrentAmount = currentAmount;
        RequirementAmount = requirementAmount;
        IsComplete = false;
    }

    public virtual void ChangeCurrentAmount(string argument)
    {
        CurrentAmount++;
        if(CurrentAmount == RequirementAmount)
        {
            IsComplete = true;
        }
    }
}
