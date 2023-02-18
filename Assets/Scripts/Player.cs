using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxStamina = 20f;
    public float stamina;
    [SerializeField] private Bar staminaBar;

    private void Awake()
    {
        stamina = maxStamina;
        staminaBar.SetMaxValue(maxStamina);
    }

    private void Update()
    {
        staminaBar.SetValue(stamina);
    }

}
