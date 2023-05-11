using Mastered.Magisteros.Actions;
using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActionHasLocation : Node
{
    private CharacterAction _action;

    public CheckActionHasLocation(CharacterAction action)
    {
        _action = action;
    }

    public override NodeState Evaluate()
    {
        if(_action.location != Vector3.zero)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
