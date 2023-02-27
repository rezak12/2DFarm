using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private Bar staminaBar;
    public float maxStamina { get; private set; } = 20f;
    public float stamina;

    [Header("Seeds")]
    [SerializeField] private SeedSlot _seedslot;
    [SerializeField] private string[] _seedTypes;
    private int _currentSeed = 0;

    private void Awake()
    {
        stamina = maxStamina;
        staminaBar.SetMaxValue(maxStamina);
    }

    private void Update()
    {
        staminaBar.SetValue(stamina);
    }

    public string GetCurrentSeed()
    {
        return _seedTypes[_currentSeed];
    }

    public void AddStaminaPoints(float stamina)
    {
        if(stamina <= 0 || stamina >= 20)
        {
            return;
        }
        maxStamina += stamina;
    }

    public void ChangeSeedInHand()
    {
        if(_currentSeed < _seedTypes.Length-1)
        {
            _currentSeed++;
        }
        else if(_currentSeed == _seedTypes.Length - 1)
        {
            _currentSeed = 0;
        }
            _seedslot.ChangeCurrentSeed(_currentSeed);
    }
}
