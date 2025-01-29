using System;
using System.Collections;
using UnityEngine;

public class CharacterHurtState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        //character.anim.SetTrigger("Hurt");
        character.CheckIfAlive();
        StartCoroutine(Stun(character));
    }

    public override void ExitState(CharacterAI character) { }

    public override void UpdateState(CharacterAI character) { }
    private IEnumerator Stun(CharacterAI character)
    {
        yield return new WaitForSeconds(0.2f);
        character.ChangeState(character.idleState);
    }
}
