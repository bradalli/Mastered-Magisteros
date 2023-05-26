using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetCharIsStaggered : Node
{
    public CharacterCombat _targetCharCombat;
    private bool nodeEntered;

    public TaskSetCharIsStaggered(CharacterCombat targetCharCombat)
    {
        _targetCharCombat = targetCharCombat;
    }

    public override NodeState Evaluate()
    {
        if (!nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Staggered)
        {
            nodeEntered = true;
            _targetCharCombat.Stagger();
            state = NodeState.RUNNING;
            return state;
        }

        if (nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Staggered)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
