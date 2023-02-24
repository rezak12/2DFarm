using UnityEngine;
using TMPro;

public class QuestBox : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private TMP_Text _questName;
    [SerializeField] private TMP_Text _questGoals;

    [SerializeField] private QuestManager _questManager;

    private void Start()
    {
        gameObject.SetActive(true);
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        Initialize();
    }

    private void Initialize()
    {
        Quest quest = _questManager.currentQuest;
        if(quest != null)
        {
            _animator.SetBool("isOpen", true);
            _questName.text = quest.QuestName;
            _questGoals.text = " ";
            for (int i = 0; i < quest.Goals.Count; i++)
            {
                _questGoals.text += $"{quest.Goals[i].GoalName} ({quest.Goals[i].CurrentAmount}/{quest.Goals[i].RequirementAmount})";
                _questGoals.text += " \n ";
            }
            
        }
        else
        {
            _questName.text = "None";
            _questGoals.text = "None";
            _animator.SetBool("isOpen", false);
        }
    }
}
