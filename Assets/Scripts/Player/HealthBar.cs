using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
