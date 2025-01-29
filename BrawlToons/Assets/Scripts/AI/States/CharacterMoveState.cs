using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterMoveState : ACharacterAIState
{
    public override void EnterState(CharacterAI character) { }

    public override void ExitState(CharacterAI character) { }

    public override void UpdateState(CharacterAI character)
    {
        if (character.playerInRange)
        {
            if (character.player.GetComponent<Player1Behaviour>().currentState == Player1Behaviour.Player1State.Attacking)
            {
                character.ChangeState(character.blockState);
            }
            else
            {
                character.ChangeState(character.attackState);
            }
        }
        else
        {
            //Aquí se mueve el personaje
            Vector3 direction = new Vector2(-1, 0);
            if (character.player.GetComponent<Player1Behaviour>().currentState == Player1Behaviour.Player1State.Walking)
            {
                direction = character.player.GetComponent<Player1Behaviour>().moveInput;
            }
            character.transform.Translate(direction.x * (direction.x < 0 ? character.moveSpeed : character.moveSpeed / 1.5f) * Time.deltaTime, 0f, 0f);
        }
    }
}
