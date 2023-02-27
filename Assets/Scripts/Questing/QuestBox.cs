using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBox : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private TMP_Text _questName;
    [SerializeField] private TMP_Text _questGoals;
    [SerializeField] private TMP_Text _reward;
    [SerializeField] private Button _closeButton;

    [SerializeField] private QuestManager _questManager;

    private void Start()
    {
        gameObject.SetActive(true);
        _animator = GetComponent<Animator>();
        _closeButton.gameObject.SetActive(false);
        _animator.SetBool("isOpen", false);
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
            _closeButton.gameObject.SetActive(true);
            _questName.text = quest.QuestName;
            _questGoals.text = " ";
            for (int i = 0; i < quest.Goals.Count; i++)
            {
                _questGoals.text += $"{quest.Goals[i].GoalName} ({quest.Goals[i].CurrentAmount}/{quest.Goals[i].RequirementAmount})";
                _questGoals.text += " \n ";
            }
            _reward.text = $"Reward: {quest.XPReward} XP";
            
        }
        else
        {
            _closeButton.gameObject.SetActive(false);
            _questName.text = "None";
            _questGoals.text = "None";
            _reward.text = "None";
            _animator.SetBool("isOpen", false);
        }
    }

    public void OpenCloseBox()
    {
        if(!_animator.GetBool("isOpen"))
        {
            _animator.SetBool("isOpen", true);
        }
        else if (_animator.GetBool("isOpen"))
        {
            _animator.SetBool("isOpen", false);
        }
    }
}
