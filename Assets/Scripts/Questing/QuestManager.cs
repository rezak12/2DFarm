using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Queue<Quest> quests = new Queue<Quest>();
    public Quest currentQuest { get; private set; }

    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioClip _audioNew;
    [SerializeField] private AudioClip _audioComplete;

    [SerializeField] private ExperinceSystem playerXP;
    void Start()
    {
        FarmArea.OnPlant += CheckChange;
    }

    public void SetNewQuest() 
    { 
        if(quests.Count > 0)
            currentQuest = quests.Dequeue();
        else
        {
            currentQuest = null;
        }
        _soundManager.PlaySound(_audioNew);
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
        {
            currentQuest.OnComplete?.Invoke(playerXP);
            SetNewQuest();
            _soundManager.PlaySound(_audioComplete);
        }
    }
}
