using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskWaitForSeconds : Node
{
    public NPCharacter _character;
    public float _seconds;

    public TaskWaitForSeconds(NPCharacter character, float seconds)
    {
        _character = character;
        _seconds = seconds;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.Wait)
        {
            _character.WaitForSecondsStart(_seconds);
        }


        if (_character.activeState == NPCharacter.states.Wait && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.WaitForSecondsEnd(_seconds);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
