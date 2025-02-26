using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaminaSliderP2 : MonoBehaviour
{

    public Slider staminaSlider; 
    public int maxStamina = 100;

    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = 0; 
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "AI")
        {
            if (staminaSlider.value != CharacterAI.instance.stamina)
            {
                staminaSlider.value = CharacterAI.instance.stamina;
            }
        }
        else
        {
            if (staminaSlider.value != Player2Control.instance.playerStateMachine.stamina)
            {
                staminaSlider.value = Player2Control.instance.playerStateMachine.stamina;
            }
        }
    }
}
