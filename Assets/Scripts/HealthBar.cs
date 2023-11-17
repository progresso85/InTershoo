using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField textinput;

    public void setMaxHealth(int maxHealth) {  
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void setTextInput(TMP_InputField textinput) { this.textinput = textinput; }

    public void setHealth(int health)
    {
        slider.value = health;
    }
}
