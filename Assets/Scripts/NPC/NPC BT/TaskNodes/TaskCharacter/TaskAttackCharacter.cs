using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAttackCharacter : Node
{
    public CharacterCombat _targetCharCombat;
    private bool nodeEntered;

    public TaskAttackCharacter(CharacterCombat targetCharCombat)
    {
        _targetCharCombat = targetCharCombat;
    }

    public override NodeState Evaluate()
    {
        if (!nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Attacking)
        {
            nodeEntered = true;
            _targetCharCombat.AttackTarget();
            state = NodeState.RUNNING;
            return state;
        }

        if (nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Attacking)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
