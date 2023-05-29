using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class TaskFleeFromCharacter : Node
{
    public NPCharacter _character;
    public CharacterCore _fleeFromChar;
    public float _desiredDistance;

    public TaskFleeFromCharacter(NPCharacter character, CharacterCore fleeFromChar, float desiredDistance)
    {
        _character = character;
        _fleeFromChar = fleeFromChar;
        _desiredDistance = desiredDistance;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.Flee)
        {
            _character.FleeStart(_fleeFromChar, _desiredDistance);
        }


        if (_character.activeState == NPCharacter.states.Flee && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.FleeEnd(_fleeFromChar, _desiredDistance);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
