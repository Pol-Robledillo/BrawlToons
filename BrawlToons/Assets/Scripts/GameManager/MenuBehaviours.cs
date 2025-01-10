using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviours : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas settings;
    public Canvas login;
    public void StartGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        mainMenu.enabled = false;
        settings.enabled = true;
    }
    public void CloseSettings()
    {
        settings.enabled = false;
        mainMenu.enabled = true;
    }
    public void OpenLogin()
    {
        mainMenu.enabled = false;
        login.enabled = true;
    }
    public void CloseLogin()
    {
        login.enabled = false;
        mainMenu.enabled = true;
    }
}
