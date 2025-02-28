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
        Vector3 direction = new Vector2(-1, 0);
        if (character.player.GetComponent<PlayerStateMachine>().currentState == PlayerStateMachine.States.attacking)
        {
            character.ChangeState(character.idleState);
        }
        else
        {
            if (character.player.GetComponent<PlayerStateMachine>().currentState == PlayerStateMachine.States.walking)
            {
                if (!character.player.GetComponent<PlayerStateMachine>().moveInput.Equals(Vector2.zero))
                {
                    direction = character.player.GetComponent<PlayerStateMachine>().moveInput;
                }
            }
            character.transform.Translate(direction.x * character.moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
