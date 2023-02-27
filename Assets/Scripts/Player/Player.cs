using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private Bar staminaBar;
    public float maxStamina { get; private set; } = 20f;
    public float stamina;

    private void Awake()
    {
        stamina = maxStamina;
        staminaBar.SetMaxValue(maxStamina);
    }

    private void Update()
    {
        staminaBar.SetValue(stamina);
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
