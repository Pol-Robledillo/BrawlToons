using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText; 
    public float timeRemaining = 99f; 
    public bool isCountingDown = false;
    public string endMessage;
    public float timeToWait = 1f;

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
                countdownText.text = endMessage;
                StartCoroutine(Hide());
            }
        }
    }
    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(timeToWait);
        countdownText.gameObject.SetActive(false);
    }
}
