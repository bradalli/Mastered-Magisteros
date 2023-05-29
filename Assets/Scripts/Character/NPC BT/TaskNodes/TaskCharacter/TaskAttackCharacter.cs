using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskAttackCharacter : Node
{
    public NPCharacter _character;
    private bool nodeEntered;

    public TaskAttackCharacter(NPCharacter character)
    {
        _character = character;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.MeleeAttack && _character.GetCombatTargetChar() != null)
        {
            _character.MeleeAttackStart();
        }


        if (_character.activeState == NPCharacter.states.MeleeAttack && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.MeleeAttackEnd();
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
