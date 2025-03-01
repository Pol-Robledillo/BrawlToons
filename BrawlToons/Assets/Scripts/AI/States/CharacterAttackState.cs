﻿using System;
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
            if (!(character.anim.GetBool("attack") || character.anim.GetBool("kick")))
            {
                character.ChangeState(character.idleState);
            }
        }
    }
    private void ExecuteAttack(CharacterAI character)
    {
        if (character.stamina >= 100)
        {
            character.anim.SetBool("special", true);
            character.stamina = 0;
        }
        if (new Random().Next(0, 2) == 0)
        {
            character.anim.SetBool("attack", true);
        }
        else
        {
            character.anim.SetBool("kick", true);
        }
    }
}
