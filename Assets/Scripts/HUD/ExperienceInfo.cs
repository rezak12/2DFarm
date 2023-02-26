using UnityEngine;
using TMPro;

public class ExperienceInfo : MonoBehaviour
{
    [SerializeField] private ExperinceSystem _experience;

    [Header("Text fields")]
    [SerializeField] private TMP_Text _currentLevel;
    [SerializeField] private TMP_Text _XPRange;


    void Update()
    {
        _currentLevel.text = $"Level {_experience.CurrentLevel}";
        _XPRange.text = $"{_experience.CurrentXP}/{_experience.RequiredXP} XP";
    }
}
