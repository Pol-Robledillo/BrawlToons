using BrawlToonsAPI.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharactersSelectedLoader : MonoBehaviour
{
    public GameObject player1SelectedCharacter;
    public GameObject player2SelectedCharacter;
    public Sprite player1SelectedCharacterSprite;
    public Sprite player2SelectedCharacterSprite;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
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
                    GameObject playerCharacter = Instantiate(player1SelectedCharacter, player.transform.position, Quaternion.identity, player.transform);
                    GameObject aiCharacter = Instantiate(player2SelectedCharacter, ai.transform.position, Quaternion.identity, ai.transform);
                    aiCharacter.layer = 7;

                    playerCharacter.transform.rotation = Quaternion.Euler(0, 90, 0);
                    aiCharacter.transform.rotation = Quaternion.Euler(0, -90, 0);

                    player.GetComponent<PlayerStateMachine>().animator = playerCharacter.GetComponent<Animator>();
                    player.GetComponent<PlayerStateMachine>().auraStamina = playerCharacter.transform.Find("Aura").gameObject;
                    player.GetComponent<Player1Control>().animator = playerCharacter.GetComponent<Animator>();
                    player.GetComponent<InputBuffer>().animator = playerCharacter.GetComponent<Animator>();

                    ai.GetComponent<CharacterAI>().anim = aiCharacter.GetComponent<Animator>();



                    player.GetComponent<Player1Control>().enabled = true;
                    ai.GetComponent<CharacterAI>().enabled = true;

                    GameObject character1Icon = GameObject.Find("Character1Icon");
                    GameObject character2Icon = GameObject.Find("Character2Icon");
                    character1Icon.GetComponent<Image>().sprite = player1SelectedCharacterSprite;
                    character2Icon.GetComponent<Image>().sprite = player2SelectedCharacterSprite;
                }
            }
            else if (scene.name == "PvP")
            {
                GameObject player1 = GameObject.Find("P1");
                GameObject player2 = GameObject.Find("P2");
                if (player1 != null && player2 != null)
                {
                    GameObject player1Character = Instantiate(player1SelectedCharacter, player1.transform.position, Quaternion.identity, player1.transform);

                    GameObject player2Character = Instantiate(player2SelectedCharacter, player2.transform.position, Quaternion.identity, player2.transform);
                    player2Character.layer = 7;

                    player1Character.transform.rotation = Quaternion.Euler(0, 90, 0);
                    player2Character.transform.rotation = Quaternion.Euler(0, -90, 0);

                    player1.GetComponent<PlayerStateMachine>().animator = player1Character.GetComponent<Animator>();
                    //player1.GetComponent<PlayerStateMachine>().auraStamina = player1Character.transform.Find("Aura").gameObject;
                    Transform[] children = player1Character.transform.GetComponentsInChildren<Transform>();
                    
                    foreach( var child in children )
                    {
                        Debug.Log(child.name);
                        if (child.name == "Aura")
                        {
                            player1.GetComponent<PlayerStateMachine>().auraStamina = child.gameObject;
                            break;
                        }
                    }
                    player1.GetComponent<Player1Control>().animator = player1Character.GetComponent<Animator>();
                    player1.GetComponent<InputBuffer>().animator = player1Character.GetComponent<Animator>();

                    player2.GetComponent<PlayerStateMachine>().animator = player2Character.GetComponent<Animator>();
                    //player2.GetComponent<PlayerStateMachine>().auraStamina = player2Character.transform.Find("Aura").gameObject;
                    Transform[] children2 = player2Character.transform.GetComponentsInChildren<Transform>();
                    foreach (var child in children2)
                    {
                        Debug.Log(child.name);
                        if (string.Equals(child.name, "Aura"))
                        {
                            player2.GetComponent<PlayerStateMachine>().auraStamina = child.gameObject;
                            break;
                        }
                    }
                    player2.GetComponent<Player2Control>().animator = player2Character.GetComponent<Animator>();
                    player2.GetComponent<InputBuffer>().animator = player2Character.GetComponent<Animator>();

                    player1.GetComponent<Player1Control>().enabled = true;
                    player2.GetComponent<Player2Control>().enabled = true;

                    GameObject character1Icon = GameObject.Find("Character1Icon");
                    GameObject character2Icon = GameObject.Find("Character2Icon");
                    character1Icon.GetComponent<Image>().sprite = player1SelectedCharacterSprite;
                    character2Icon.GetComponent<Image>().sprite = player2SelectedCharacterSprite;
                }
            }
            else if (scene.name != "CharacterSelection" && scene.name != "CharacterSelectionAI")
            {
                Destroy(this.gameObject);
            }
        }
    }
}