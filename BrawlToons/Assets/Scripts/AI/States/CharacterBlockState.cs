using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterBlockState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        character.isBlocking = true;
        character.anim.SetBool("isBlocking", character.isBlocking);
    }

    public override void ExitState(CharacterAI character)
    {
        character.isBlocking = false;
        character.anim.SetBool("isBlocking", character.isBlocking);
    }

    public override void UpdateState(CharacterAI character)
    {
        if (character.player.GetComponent<Player1Behaviour>().currentState != Player1Behaviour.Player1State.Attacking)
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
