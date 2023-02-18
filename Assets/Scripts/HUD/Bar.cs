using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private bool usingGradient;

    public void SetMaxValue(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        if(usingGradient)
            fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float health)
    {
        slider.value = health;
        if (usingGradient)
            fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
