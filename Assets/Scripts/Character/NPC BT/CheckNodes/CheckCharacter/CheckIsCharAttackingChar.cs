using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharAttackingChar : Node
{
    private NPCharacter _character;
    private CharacterCore _targetCharacter;

    public CheckIsCharAttackingChar(NPCharacter character, NPCharacter targetCharacter)
    {
        _character = character;
        _targetCharacter = targetCharacter;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState == NPCharacter.states.MeleeAttack && _character.GetCombatTargetChar() == _targetCharacter)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
