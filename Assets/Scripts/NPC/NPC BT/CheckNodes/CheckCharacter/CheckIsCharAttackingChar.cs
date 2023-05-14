using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharAttackingChar : Node
{
    private Character _character;
    private Character _targetCharacter;

    public CheckIsCharAttackingChar(Character character, Character targetCharacter)
    {
        _character = character;
        _targetCharacter = targetCharacter;
    }

    public override NodeState Evaluate()
    {
        if (_character.isInCombat)
        {
            if(_character.isAttacking && _character.combatTarget == _targetCharacter)
            {
                state = NodeState.SUCCESS;
                return state;
            }
        }

        state = NodeState.FAILURE;
        return state;
    }
}
