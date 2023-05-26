using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharacterThisType : Node
{
    private Character _character;
    private Character.Personality _personality;

    public CheckIsCharacterThisType(Character character, Character.Personality personality)
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
