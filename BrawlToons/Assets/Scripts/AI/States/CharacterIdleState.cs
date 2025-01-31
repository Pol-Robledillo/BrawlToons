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
        if (!(character.player.GetComponentInChildren<Animator>().GetBool("attack") || character.player.GetComponentInChildren<Animator>().GetBool("kick")))
        {
            character.ChangeState(character.moveState);
        }
    }
}
