using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskWander : Node
{
    public NPCharacter _character;
    private bool nodeEntered;

    public TaskWander(NPCharacter character)
    {
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.Wander)
        {
            _character.WanderStart();
            return NodeState.RUNNING;
        }


        if (_character.activeState == NPCharacter.states.Wander && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.WanderEnd();
            return NodeState.SUCCESS;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
