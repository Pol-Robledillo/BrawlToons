using System;
using System.Collections;
using UnityEngine;

public class CharacterHurtState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        //character.anim.SetTrigger("Hurt");
    }

    public override void ExitState(CharacterAI character) { }

    public override void UpdateState(CharacterAI character)
    {
        if (character.CheckIfAlive())
        {
            character.ChangeState(character.idleState);
        }
    }
}
