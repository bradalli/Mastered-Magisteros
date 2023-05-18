using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttackCharacter : Node
{
    public CharacterCombat _ownerCharacter;
    public Character _targetCharacter;

    public TaskAttackCharacter(CharacterCombat ownerCharacter, Character targetCharacter)
    {
        _ownerCharacter = ownerCharacter;
        _targetCharacter = targetCharacter;
    }

    public override NodeState Evaluate()
    {
        if (!_ownerCharacter.attemptAttack)
        {
            _ownerCharacter.AttackTarget(_targetCharacter);
            _ownerCharacter.attemptAttack = true;
        }

        else if(_ownerCharacter.isAttacking)
        {
            state = NodeState.RUNNING;
        }

        else
        {
            state = NodeState.SUCCESS;
            _ownerCharacter.attemptAttack = false;
        }

        return state;
    }
}
