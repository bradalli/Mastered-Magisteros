using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBlock : Node
{
    public Character _ownerCharacter;
    public Character _targetCharacter;

    public TaskBlock(Character ownerCharacter, Character targetCharacter)
    {
        _ownerCharacter = ownerCharacter;
    }

    public override NodeState Evaluate()
    {
        if (!_ownerCharacter.attemptBlock)
        {
            _ownerCharacter.Block();
            _ownerCharacter.attemptBlock = true;
        }

        else if (_ownerCharacter.isBlocking)
        {
            state = NodeState.RUNNING;
        }

        else
        {
            state = NodeState.SUCCESS;
            _ownerCharacter.attemptBlock = false;
        }

        return state;
    }
}
