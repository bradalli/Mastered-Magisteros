using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class TaskMaintainDistanceFromChar : Node
{
    public NPCharacter _character;
    public CharacterCore _fromCharacter;
    public float _desiredDistance;

    private bool nodeEntered;

    public TaskMaintainDistanceFromChar(NPCharacter character, float desiredDistance)
    {
        _character = character;
        _desiredDistance = desiredDistance;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.MeleeEvade && _character.GetCombatTargetChar() != null)
        {
            _character.MeleeEvadeStart(_fromCharacter, _desiredDistance);
        }


        if (_character.activeState == NPCharacter.states.MeleeEvade && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.MeleeEvadeEnd(_fromCharacter, _desiredDistance);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
