using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider: MonoBehaviour
{

    public Slider staminaSlider; 
    public int maxStamina = 100;

    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = Player1Control.instance.playerStateMachine.stamina; 
    }

    void Update()
    {
        if (staminaSlider.value != Player1Control.instance.playerStateMachine.stamina)
        {
            staminaSlider.value = Player1Control.instance.playerStateMachine.stamina;
        }
    }
}
