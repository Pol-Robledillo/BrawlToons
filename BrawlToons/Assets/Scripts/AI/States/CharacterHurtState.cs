using System;
using System.Collections;
using UnityEngine;

public class CharacterHurtState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        character.anim.SetBool("Hurt", true);
    }

    public override void ExitState(CharacterAI character) { }

    public override void UpdateState(CharacterAI character)
    {
        if (character.CheckIfAlive())
        {
            character.anim.SetBool("Hurt", false);
            character.ChangeState(character.idleState);
        }
    }
}
