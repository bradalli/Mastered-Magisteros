using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBlock : Node
{
    public CharacterCombat _ownerCharacter;
    public CharacterCombat _targetCharacter;

    public TaskBlock(CharacterCombat ownerCharacter, CharacterCombat targetCharacter)
    {
        _ownerCharacter = ownerCharacter;
        _targetCharacter = targetCharacter;
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
