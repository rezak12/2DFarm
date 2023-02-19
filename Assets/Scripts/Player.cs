using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxStamina = 20f;
    public float stamina;
    [SerializeField] private Bar staminaBar;
    [SerializeField] private string[] _seedTypes;
    private int _currentSeed = 0;
    [SerializeField] private SeedSlot _seedslot;

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
}
