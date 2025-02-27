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
                    player.GetComponent<Character>().ParticleHit = playerCharacter.transform.Find("ParticleHit").GetComponent<ParticleSystem>();

                    ai.GetComponent<CharacterAI>().anim = aiCharacter.GetComponent<Animator>();
                    player.GetComponent<Character>().ParticleHit = aiCharacter.transform.Find("ParticleHit").GetComponent<ParticleSystem>();


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
                    player1.GetComponent<PlayerStateMachine>().auraStamina = player1Character.transform.Find("Aura").gameObject;
                    player1.GetComponent<Player1Control>().animator = player1Character.GetComponent<Animator>();
                    player1.GetComponent<InputBuffer>().animator = player1Character.GetComponent<Animator>();
                    player1.GetComponent<Character>().ParticleHit = player1Character.transform.Find("ParticleHit").GetComponent<ParticleSystem>();

                    player2.GetComponent<PlayerStateMachine>().animator = player2Character.GetComponent<Animator>();
                    player2.GetComponent<PlayerStateMachine>().auraStamina = player2Character.transform.Find("Aura").gameObject;
                    player2.GetComponent<Player2Control>().animator = player2Character.GetComponent<Animator>();
                    player2.GetComponent<InputBuffer>().animator = player2Character.GetComponent<Animator>();
                    player2.GetComponent<Character>().ParticleHit = player2Character.transform.Find("ParticleHit").GetComponent<ParticleSystem>();

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