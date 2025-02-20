using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Character.asset", menuName = "Characters/Character")]

public class CharacterSO : ScriptableObject
{
    public int characterID;
    public string characterName;
    public GameObject characterPrefab;
}
