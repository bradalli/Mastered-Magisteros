using Mastered.Magisteros.Actions;
using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsActionThisType : Node
{
    private CharacterAction _action;
    private CharacterAction.ActionType _type;

    public CheckIsActionThisType(CharacterAction action, CharacterAction.ActionType type)
    {
        _action = action;
        _type = type;
    }

    public override NodeState Evaluate()
    {
        if(_action.type == _type)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
