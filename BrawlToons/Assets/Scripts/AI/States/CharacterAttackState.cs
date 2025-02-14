using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterAttackState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        ExecuteAttack(character);
    }

    public override void ExitState(CharacterAI character) { }

    public override void UpdateState(CharacterAI character)
    {
        if (character.playerInRange)
        {
            ExecuteAttack(character);
        }
        else
        {
            character.ChangeState(character.idleState);
        }
    }
    private void ExecuteAttack(CharacterAI character)
    {
        if (new Random().Next(0, 1) == 0)
        {
            character.anim.SetBool("attack", true);
        }
        else
        {
            character.anim.SetBool("kick", true);
        }
    }
}
