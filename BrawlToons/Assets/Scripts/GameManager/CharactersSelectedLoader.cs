using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactersSelectedLoader : MonoBehaviour
{
    public GameObject player1SelectedCharacter;
    public GameObject player2SelectedCharacter;
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
        if (scene != null)
        {
            if (scene.name == "AI")
            {
                GameObject player = GameObject.Find("P1");
                GameObject ai = GameObject.Find("P2");
                Debug.Log(player);
                Debug.Log(ai);
                if (player != null && ai != null)
                {
                    Debug.Log("Player and AI found");
                    GameObject playerCharacter = Instantiate(player1SelectedCharacter, player.transform.position, Quaternion.identity, player.transform);
                    GameObject aiCharacter = Instantiate(player2SelectedCharacter, ai.transform.position, Quaternion.identity, ai.transform);

                    playerCharacter.transform.rotation = Quaternion.Euler(0, 90, 0);
                    aiCharacter.transform.rotation = Quaternion.Euler(0, -90, 0);

                    player.GetComponent<PlayerStateMachine>().animator = playerCharacter.GetComponent<Animator>();
                    player.GetComponent<Player1Control>().animator = playerCharacter.GetComponent<Animator>();
                    player.GetComponent<InputBuffer>().animator = playerCharacter.GetComponent<Animator>();

                    ai.GetComponent<CharacterAI>().anim = aiCharacter.GetComponent<Animator>();

                    player.GetComponent<Player1Control>().enabled = true;
                    ai.GetComponent<CharacterAI>().enabled = true;
                }
            }
            else if (scene.name == "PvP")
            {
                GameObject player1 = GameObject.Find("P1");
                GameObject player2 = GameObject.Find("P2");
                if (player1 != null && player2 != null)
                {
                    Debug.Log("Player 1 and Player 2 found");
                    GameObject player1Character = Instantiate(player1SelectedCharacter, player1.transform.position, Quaternion.identity, player1.transform);
                    GameObject player2Character = Instantiate(player2SelectedCharacter, player2.transform.position, Quaternion.identity, player2.transform);

                    player1Character.transform.rotation = new Quaternion(0, 90, 0, 0);
                    player2Character.transform.rotation = new Quaternion(0, -90, 0, 0);

                    player1.GetComponent<PlayerStateMachine>().animator = player1Character.GetComponent<Animator>();
                    player1.GetComponent<Player1Control>().animator = player1Character.GetComponent<Animator>();
                    player1.GetComponent<InputBuffer>().animator = player1Character.GetComponent<Animator>();

                    player2.GetComponent<PlayerStateMachine>().animator = player2Character.GetComponent<Animator>();
                    player2.GetComponent<Player1Control>().animator = player2Character.GetComponent<Animator>();
                    player2.GetComponent<InputBuffer>().animator = player2Character.GetComponent<Animator>();

                    player1.GetComponent<Player1Control>().enabled = true;
                    player2.GetComponent<Player2Control>().enabled = true;
                }
            }
            else if (scene.name != "CharacterSelection" || scene.name != "CharacterSelectionAI")
            {
                Destroy(this.gameObject);
            }
        }
    }
}