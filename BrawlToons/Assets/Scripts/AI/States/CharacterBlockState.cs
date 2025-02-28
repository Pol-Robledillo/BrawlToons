using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterBlockState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        character.isBlocking = true;
        character.anim.SetBool("block", character.isBlocking);
    }

    public override void ExitState(CharacterAI character)
    {
        character.isBlocking = false;
        character.anim.SetBool("block", character.isBlocking);
    }

    public override void UpdateState(CharacterAI character)
    {
        if (!(character.player.GetComponentInChildren<Animator>().GetBool("attack") || character.player.GetComponentInChildren<Animator>().GetBool("kick")))
        {
            if(character.playerInRange)
            {
                character.ChangeState(character.attackState);
            }
            else
            {
                character.ChangeState(character.idleState);
            }
        }
    }
}
