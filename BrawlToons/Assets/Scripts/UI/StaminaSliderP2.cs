using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSliderP2 : MonoBehaviour
{

    public Slider staminaSlider; 
    public int maxStamina = 100;

    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = Player2Control.instance.playerStateMachine.stamina; 
    }

    void Update()
    {
        if (staminaSlider.value != Player2Control.instance.playerStateMachine.stamina)
        {
            staminaSlider.value = Player2Control.instance.playerStateMachine.stamina;
        }
    }
}
