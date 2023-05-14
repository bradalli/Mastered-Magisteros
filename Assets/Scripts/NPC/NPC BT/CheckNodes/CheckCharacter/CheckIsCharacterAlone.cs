using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharacterAlone : Node
{
    private CharacterAwareness _characterAwareness;

    public CheckIsCharacterAlone(CharacterAwareness characterAwareness)
    {
        _characterAwareness = characterAwareness;
    }

    public override NodeState Evaluate()
    {
        if(_characterAwareness.nearbyAlliesNum == 0)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
