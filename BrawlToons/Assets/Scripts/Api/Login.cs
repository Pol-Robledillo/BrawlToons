using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField password;
    public TMP_InputField user2;
    public TMP_InputField password2;
    public TMP_Text players;
    private PlayerController playerController;

    public void Start()
    {
        playerController = GetComponent<PlayerController>();
        players.text = $"Player 1:{PlayerPrefs.GetString("NamePlayer1"," ")} Player 2: {PlayerPrefs.GetString("NamePlayer2"," ")}";
    }
    public void OnLogin()
    {
        //llamar funcion login de la api
        playerController.VerifyUserFunc(user.text, password.text);
        StartCoroutine(GetRequest(1));
    }
    public void OnLogin2()
    {
        //llamar funcion login de la api
        playerController.VerifyUserFunc(user2.text, password2.text);
        StartCoroutine(GetRequest(2));
    }
    public IEnumerator GetRequest(int playerNum)
    {
        yield return new WaitForSeconds(1f);
        if (playerController.reqSucces)
        {
            if (playerNum == 1)
            {
                PlayerPrefs.SetInt("IdPlayer1", playerController.reqPlayer.player_id);
                PlayerPrefs.SetString("NamePlayer1", playerController.reqPlayer.username);
            }
            else
            {
                PlayerPrefs.SetInt("IdPlayer2", playerController.reqPlayer.player_id);
                PlayerPrefs.SetString("NamePlayer2", playerController.reqPlayer.username);
            }
        }
        players.text = $"P1 : {PlayerPrefs.GetString("NamePlayer1", " ")} P2 : {PlayerPrefs.GetString("NamePlayer2", " ")}";
        Debug.Log("Player 1 id: "+PlayerPrefs.GetInt("IdPlayer1"));
        Debug.Log("Player 2 id: " + PlayerPrefs.GetInt("IdPlayer2"));
    }
}
