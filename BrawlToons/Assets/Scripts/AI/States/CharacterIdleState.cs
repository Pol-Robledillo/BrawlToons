using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterIdleState : ACharacterAIState
{
    public override void EnterState(CharacterAI character) { }

    public override void ExitState(CharacterAI character) { }

    public override void UpdateState(CharacterAI character)
    {
        if (character.player.GetComponent<PlayerStateMachine>().currentState != PlayerStateMachine.States.attacking)
        {
            character.ChangeState(character.moveState);
        }
    }
}
