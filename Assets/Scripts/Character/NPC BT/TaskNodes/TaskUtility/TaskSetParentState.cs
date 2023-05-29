using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskSetParentState : Node
{
    public NPCharacter _character;
    public NPCBT.BehaviourTree _newTree;

    public TaskSetParentState(NPCharacter character, NPCBT.BehaviourTree newTree)
    {
        _character = character;
        _newTree = newTree;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.ChangingParentState)
        {
            _character.SetParentStateStart(_newTree);
        }


        if (_character.activeState == NPCharacter.states.ChangingParentState && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.SetParentStateEnd(_newTree);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
