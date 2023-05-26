using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharacterThisType : Node
{
    private Mastered.Magisteros.NPC.CharacterCombat _character;
    private Mastered.Magisteros.NPC.CharacterCombat.Personality _personality;

    public CheckIsCharacterThisType(Mastered.Magisteros.NPC.CharacterCombat character, Mastered.Magisteros.NPC.CharacterCombat.Personality personality)
    {
        _character = character;
        _personality = personality;
    }

    public override NodeState Evaluate()
    {
        if(_character.personality == _personality)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
