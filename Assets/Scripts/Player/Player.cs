using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private Bar staminaBar;
    [SerializeField][Range(0, 5)] int someValue = 0;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            someValue++;
        }
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
