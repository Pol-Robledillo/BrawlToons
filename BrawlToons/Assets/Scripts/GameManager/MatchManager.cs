using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{
    public GameObject startTimer;
    public TimeCountDown startCountDown;

    public GameObject gameTimer;
    public TimeCountDown gameCountDown;

    public GameObject winnerMessage;
    public TextMeshProUGUI winnerText;

    private void Update()
    {
        if (startCountDown.isCountingDown == false)
        {
            gameCountDown.isCountingDown = true;
            GameObject.Find("P1").GetComponent<Player1Control>().enabled = true;
            if (SceneManager.GetActiveScene().name == "AI")
            {
                GameObject.Find("P2").GetComponent<CharacterAI>().enabled = true;
            }
            else
            {
                GameObject.Find("P2").GetComponent<Player2Control>().enabled = true;
            }
        }
        if (gameCountDown.timeRemaining == 0)
        {
            Character player1Character = GameObject.Find("P1").GetComponent<Character>();
            Character player2Character = GameObject.Find("P2").GetComponent<Character>();
            if (player1Character.health > player2Character.health)
            {
                EndGame(1);
            }
            else if (player1Character.health < player2Character.health)
            {
                EndGame(2);
            }
            else
            {
                EndGame(1);
            }
        }
    }
    public void EndGame(int playerWinner)
    {
        Debug.Log("Player " + playerWinner + " Wins!");
        GameObject.Find("P1").GetComponent<Player1Control>().enabled = false;
        if (SceneManager.GetActiveScene().name == "AI")
        {
            GameObject.Find("P2").GetComponent<CharacterAI>().enabled = false;
        }
        else
        {
            GameObject.Find("P2").GetComponent<Player2Control>().enabled = false;
        }
        if (SceneManager.GetActiveScene().name == "PvP")
        {
            GetComponent<PostMatch>().OnFinishMatch(PlayerPrefs.GetInt("IdPlayer" + playerWinner.ToString()));
        }
        winnerText.text = playerWinner == 1 ? "Player 1 Wins!" : "Player 2 Wins!";
        winnerMessage.SetActive(true);
        StartCoroutine(Exit());
    }
    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}
