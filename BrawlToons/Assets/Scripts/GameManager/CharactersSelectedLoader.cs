using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactersSelectedLoader : MonoBehaviour
{
    public GameObject player1SelectedCharacter;
    public GameObject player2SelectedCharacter;
    public GameObject player1;
    public GameObject player2;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Update()
    {
        
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {

    }
}
