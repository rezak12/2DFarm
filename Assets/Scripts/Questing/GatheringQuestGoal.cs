[System.Serializable]
public class GatheringQuestGoal : QuestGoal
{
    public string PlantName { get; private set; }
    public GatheringQuestGoal(string goalName, int currentAmount, int requirementAmount, string plantName) : base(goalName, currentAmount, requirementAmount)
    {
        this.PlantName = plantName;
    }


    public override void ChangeCurrentAmount(string argument)
    {
        if(argument != PlantName)
            return;
        
        base.ChangeCurrentAmount(argument);
    }
}
