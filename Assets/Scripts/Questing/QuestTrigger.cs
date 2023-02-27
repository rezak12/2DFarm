using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] QuestManager _questManager;
    [SerializeField] string QuestName;
    [SerializeField] string[] GoalArguments;
    [SerializeField] int XPReward;
    private Quest _quest;
    private bool isSended;
    void Start()
    {
        isSended = false;
        _quest = new GatheringQuest(QuestName, new List<QuestGoal>(), XPReward);
        for (int i = 0; i < GoalArguments.Length; i++)
        {
            int amount = Random.Range(3, 10);
            _quest.Goals.Add(new GatheringQuestGoal($"Plant {amount} {GoalArguments[i]}", 0, amount, GoalArguments[i]));
        }
    }

    public void TriggerQuest()
    {
        if (isSended)
        {
            return;
        }
        _questManager.TakeNewQuest(_quest);
        isSended = true;
    }

}
