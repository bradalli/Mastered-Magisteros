using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskBlock : Node
{
    public NPCharacter _character;

    private bool nodeEntered;

    public TaskBlock(NPCharacter character)
    {
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.MeleeBlock && _character.GetCombatTargetChar() != null)
        {
            _character.MeleeBlockStart();
        }


        if (_character.activeState == NPCharacter.states.MeleeBlock && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.MeleeBlockEnd();
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
