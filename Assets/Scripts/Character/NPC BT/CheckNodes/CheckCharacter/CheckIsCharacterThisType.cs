using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharacterThisType : Node
{
    private NPCharacter _character;
    private Personality.personalityTypes _personality;

    public CheckIsCharacterThisType(NPCharacter character, Personality.personalityTypes personality)
    {
        _character = character;
        _personality = personality;
    }

    public override NodeState Evaluate()
    {
        if(_character.GetPersonality() == _personality)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
