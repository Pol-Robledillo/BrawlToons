using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField user;
    public InputField password;
    
    public void OnLogin()
    {
        //llamar funcion login de la api
        BrawlToonsAPI.Models.Player newPlayer = new BrawlToonsAPI.Models.Player(user.text, password.text) { };
        
    }
}
