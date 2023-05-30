using Mastered.Magisteros.Actions;
using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsActionThisType : Node
{
    private CharacterAction _action;
    private CharacterAction.ActionType _type;
    private bool _invert;

    public CheckIsActionThisType(CharacterAction action, CharacterAction.ActionType type, bool invert)
    {
        _action = action;
        _type = type;
        _invert = invert;
    }

    public override NodeState Evaluate()
    {
        if(_action.type == _type && !_invert)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        if (_action.type != _type && _invert)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
