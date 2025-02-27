using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText; 
    private float timeRemaining = 99f; 
    private bool isCountingDown = true;

    void Update()
    {
        if (isCountingDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; 
                countdownText.text = Mathf.Ceil(timeRemaining).ToString(); 
            }
            else
            {
                timeRemaining = 0;
                isCountingDown = false; 
                countdownText.text = "End!";
            }
        }
    }
}
