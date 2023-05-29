using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetWPIndex : Node
{
    public NPCharacter _character;
    public int _index;

    public TaskSetWPIndex(NPCharacter character, int index)
    {
        _character = character;
        _index = index;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.Wait)
        {
            _character.SetWpIndexStart(_index);
        }


        if (_character.activeState == NPCharacter.states.Wait && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.SetWpIndexEnd(_index);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
