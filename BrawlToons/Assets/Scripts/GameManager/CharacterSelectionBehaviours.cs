using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionBehaviours : MonoBehaviour
{
    private bool characterOneSelected = false, characterTwoSelected = false;
    public GameObject playerOneCharacter, playerTwoCharacter;
    public Image playerOneButton, playerTwoButton;
    public TextMeshProUGUI textButtonPlayerOne, textButtonPlayerTwo;
    public void SetPlayerCharacter(CharacterSO character)
    {
        if (!characterOneSelected)
        {
            playerOneCharacter.GetComponent<MeshFilter>().mesh = character.mesh;
            playerOneCharacter.GetComponent<MeshRenderer>().material = character.material;
        }
        else if (!characterTwoSelected)
        {
            playerTwoCharacter.GetComponent<MeshFilter>().mesh = character.mesh;
            playerTwoCharacter.GetComponent<MeshRenderer>().material = character.material;
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
                textButtonPlayerOne.color = characterOneSelected ? Color.white : Color.black;
                playerOneButton.color = characterOneSelected ? Color.grey : Color.green;
            }
        }
        else
        {
            if (characterOneSelected)
            {
                characterTwoSelected = !characterTwoSelected;
                textButtonPlayerTwo.text = characterTwoSelected ? "Cancel" : "Select";
                textButtonPlayerTwo.color = characterTwoSelected ? Color.white : Color.black;
                playerTwoButton.color = characterTwoSelected ? Color.grey : Color.green;
            }
        }
    }
    public void StartGame()
    {
        if (characterOneSelected && characterTwoSelected)
        {
            SceneManager.LoadScene("Camera");
        }
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
