using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacterAIState : MonoBehaviour
{
    public abstract void EnterState(CharacterAI character);
    public abstract void UpdateState(CharacterAI character);
    public abstract void ExitState(CharacterAI character);
}
