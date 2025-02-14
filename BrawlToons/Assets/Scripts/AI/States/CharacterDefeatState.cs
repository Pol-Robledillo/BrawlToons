using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterDefeatState : ACharacterAIState
{
    public override void EnterState(CharacterAI character)
    {
        //character.anim.SetBool("isDefeated", true);
    }

    public override void ExitState(CharacterAI character)
    {
    }

    public override void UpdateState(CharacterAI character)
    {
    }
}
