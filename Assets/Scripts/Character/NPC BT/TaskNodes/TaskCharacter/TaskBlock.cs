using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBlock : Node
{
    public CharacterCombat _targetCharCombat;

    private bool nodeEntered;

    public TaskBlock(CharacterCombat targetCharCombat)
    {
        _targetCharCombat = targetCharCombat;
    }

    public override NodeState Evaluate()
    {
        if (!nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Blocking)
        {
            nodeEntered = true;
            _targetCharCombat.Block();
            state = NodeState.RUNNING;
            return state;
        }

        if (nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Blocking)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
