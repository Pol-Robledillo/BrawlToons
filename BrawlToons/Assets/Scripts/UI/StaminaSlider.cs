using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{

    public Character character; 
    public Slider staminaSlider; 
    public int maxStamina = 100;

    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = character.stamina; 
    }

    void Update()
    {
        if (staminaSlider.value != character.stamina)
        {
            staminaSlider.value = character.stamina;
        }
    }
}
