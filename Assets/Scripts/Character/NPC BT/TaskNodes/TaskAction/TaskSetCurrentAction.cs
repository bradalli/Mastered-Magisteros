using Mastered.Magisteros.Actions;
using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetCurrentAction : Node
{
    public CharacterAction _action;
    public CharacterCore _character;

    public TaskSetCurrentAction(CharacterAction action, CharacterCore character)
    {
        _action = action;
        _character = character;
    }

    public override NodeState Evaluate()
    {
        _character.currentAction = _action;

        state = NodeState.SUCCESS;
        return state;
    }
}
