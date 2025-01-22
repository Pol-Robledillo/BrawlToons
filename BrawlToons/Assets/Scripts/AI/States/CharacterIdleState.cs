using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterIdleState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {

    }

    public override void ExitState(CharacterAI character)
    {
        throw new NotImplementedException();
    }

    public override void UpdateState(CharacterAI character)
    {
        if (!character.player.GetComponent<Player1Control>().isAttacking)
        {
            character.ChangeState(character.moveState);
        }
    }
}
