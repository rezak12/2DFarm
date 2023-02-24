[System.Serializable]
public class GatheringQuestGoal : QuestGoal
{
    public GatheringQuestGoal(string goalName, int currentAmount, int requirementAmount, string plantName) : base(goalName, currentAmount, requirementAmount)
    {
        this.PlantName = plantName;
    }

    public string PlantName { get; private set; }

    public override void ChangeCurrentAmount(string argument)
    {
        if(argument != PlantName)
        {
            return;
        }
        
        base.ChangeCurrentAmount(argument);
    }
}
