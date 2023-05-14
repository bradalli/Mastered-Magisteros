using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHasCharacterBeenAttacked : Node
{
    private float _sinceTime;
    private Character _character;

    public CheckHasCharacterBeenAttacked(float sinceTime, Character character)
    {
        _sinceTime = sinceTime;
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if(_character.timeLastReceivedAttack > _sinceTime)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
