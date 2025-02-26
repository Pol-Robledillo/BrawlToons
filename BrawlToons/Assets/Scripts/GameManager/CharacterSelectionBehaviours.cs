using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionBehaviours : MonoBehaviour
{
    private bool characterOneSelected = false, characterTwoSelected = false;
    public Image playerOneButton, playerTwoButton;
    public TextMeshProUGUI textButtonPlayerOne, textButtonPlayerTwo;
    public GameObject[] charactersPlayer1;
    public GameObject[] charactersPlayer2;
    public CharactersSelectedLoader charactersSelectedLoader;
    public void SetPlayerCharacter(CharacterSO character)
    {
        if (!characterOneSelected)
        {
            foreach (var characterPlayer in charactersPlayer1)
            {
                characterPlayer.SetActive(false);
            }
            charactersPlayer1[character.characterID].SetActive(true);
            charactersSelectedLoader.player1SelectedCharacter = character.characterPrefab;
            charactersSelectedLoader.player1SelectedCharacterSprite = character.characterIcon;
            PlayerPrefs.SetInt("Player1Character", character.characterID);
        }
        else if (!characterTwoSelected)
        {
            foreach (var characterPlayer in charactersPlayer2)
            {
                characterPlayer.SetActive(false);
            }
            charactersPlayer2[character.characterID].SetActive(true);
            charactersSelectedLoader.player2SelectedCharacter = character.characterPrefab;
            charactersSelectedLoader.player2SelectedCharacterSprite = character.characterIcon;
            PlayerPrefs.SetInt("Player2Character", character.characterID);
        }
    }
    public void ToggleCharacterSelection(bool playerOne)
    {
        if (playerOne)
        {
            if (!characterTwoSelected)
            {
                characterOneSelected = !characterOneSelected;
                textButtonPlayerOne.text = characterOneSelected ? "Cancel" : "Select";
                playerOneButton.color = characterOneSelected ? Color.grey : Color.green;
            }
        }
        else
        {
            if (characterOneSelected)
            {
                characterTwoSelected = !characterTwoSelected;
                textButtonPlayerTwo.text = characterTwoSelected ? "Cancel" : "Select";
                playerTwoButton.color = characterTwoSelected ? Color.grey : Color.green;
            }
        }
    }
    public void StartGame()
    {
        if (characterOneSelected && characterTwoSelected)
        {
            if (SceneManager.GetActiveScene().name == "CharacterSelectionAI")
            {
                SceneManager.LoadScene("AI");
            }
            else
            {
                SceneManager.LoadScene("PvP");
            }
        }
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}