using Mastered.Magisteros.Actions;
using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTriggerAction : Node
{
    public NPCharacter _character;

    public TaskTriggerAction(NPCharacter character)
    {
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.Act && _character.currentAction != null)
        {
            _character.ActStart();
        }
            

        if(_character.activeState == NPCharacter.states.Act && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.ActEnd();
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
