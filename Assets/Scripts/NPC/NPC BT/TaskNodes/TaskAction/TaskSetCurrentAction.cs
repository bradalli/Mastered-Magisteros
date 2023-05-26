using Mastered.Magisteros.Actions;
using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetCurrentAction : Node
{
    public CharacterAction _action;
    public Mastered.Magisteros.NPC.CharacterCombat _character;

    public TaskSetCurrentAction(CharacterAction action, Mastered.Magisteros.NPC.CharacterCombat character)
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
