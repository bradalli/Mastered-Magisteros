using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWander : Node
{
    public CharacterCore _targetChar;
    private bool nodeEntered;

    public TaskWander(CharacterCore targetChar)
    {
        _targetChar = targetChar;
    }

    public override NodeState Evaluate()
    {
        if (!nodeEntered && _targetChar.currentState != CharacterCombat.combatState.Attacking)
        {
            nodeEntered = true;
            _targetChar.AttackTarget();
            state = NodeState.RUNNING;
            return state;
        }

        if (nodeEntered && _targetChar.currentState != CharacterCombat.combatState.Attacking)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
