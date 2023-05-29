using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskSetCharIsStaggered : Node
{
    public NPCharacter _character;

    public TaskSetCharIsStaggered(NPCharacter character)
    {
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.Stagger)
        {
            _character.StaggerStart();
        }


        if (_character.activeState == NPCharacter.states.Stagger && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.StaggerEnd();
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
