using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTriggerAction : Node
{
    public Mastered.Magisteros.NPC.Character _character;

    public TaskTriggerAction(Mastered.Magisteros.NPC.Character character)
    {
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if (!_character.isAnActionBeingPerformed && _character.currentAction != null)
        {
            _character.currentAction.TriggerAction();
            _character.isAnActionBeingPerformed = true;
        }
            

        else if(_character.currentAction == null)
        {
            _character.isAnActionBeingPerformed = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
