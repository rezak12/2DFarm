using UnityEngine;

public class ExperinceSystem : MonoBehaviour
{
    public int CurrentLevel { get; private set; } = 1;
    public int CurrentXP { get; private set; }
    public int RequiredXP { get; private set; }

    [SerializeField] private float _additionMultiplier = 300f;
    [SerializeField] private float _powerMultiplier = 2f;
    [SerializeField] private float _divisionMultiplier = 2f;


    private void Start()
    {
        RequiredXP = CalculateRequiredXP();
    }
    public void TakeXP(int XP)
    {
        if (XP <= 0)
            return;
        CurrentXP += XP;
        if (CurrentXP > RequiredXP)
            LevelUp();
    }

    private void LevelUp()
    {
        CurrentLevel++;
        GetComponent<Player>().AddStaminaPoints(2);
        CurrentXP = Mathf.RoundToInt(CurrentXP - RequiredXP);
        RequiredXP = CalculateRequiredXP();
    }

    private int CalculateRequiredXP()
    {
        int solveForRequiredXp = 0;
        for (int i = 0; i < CurrentLevel; i++)
        {
            solveForRequiredXp += (int)Mathf.Floor(i + _additionMultiplier * Mathf.Pow(_powerMultiplier, i / _divisionMultiplier));
        }
        return solveForRequiredXp / 4;
    }
}
