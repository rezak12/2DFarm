using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxStamina { get; private set; } = 20f;
    public float stamina;
    [SerializeField] private Bar staminaBar;
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

        if (Input.GetMouseButtonDown(0))
        { 
                if(_currentSeed > 0)
                {
                    _currentSeed--;
                    _seedslot.ChangeCurrentSeed(_currentSeed);
                }
        }
        else if (Input.GetMouseButtonDown(1))
            if (_currentSeed < _seedTypes.Length-1)
            {
                _currentSeed++;
                _seedslot.ChangeCurrentSeed(_currentSeed);
            }
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
}
