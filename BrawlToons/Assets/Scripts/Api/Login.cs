using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField password;
    private PlayerController playerController;

    public void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void OnLogin()
    {
        //llamar funcion login de la api
        BrawlToonsAPI.Models.Player newPlayer = new BrawlToonsAPI.Models.Player(user.text, password.text) { };
        playerController.VerifyUserFunc(user.text, password.text);
        
    }
}
