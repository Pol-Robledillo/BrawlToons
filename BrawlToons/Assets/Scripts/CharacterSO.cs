using UnityEngine;
[CreateAssetMenu(fileName = "Character.asset", menuName = "Characters/Character")]

public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Mesh mesh;
    public Material material;
}
