using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class TaskGoToPosition : Node
{
    public NPCharacter _character;
    public Vector3 _desiredPosition;
    private NPCharacter.states _desiredType;

    public TaskGoToPosition(NPCharacter character, Vector3 desiredPosition, NPCharacter.states desiredType)
    {
        _character = character;
        _desiredPosition = desiredPosition;
        _desiredType = desiredType;
    }

    public override NodeState Evaluate()
    {
        switch (_desiredType)
        {
            case NPCharacter.states.Travel:
                #region Travel call
                if (_character.activeState != NPCharacter.states.Travel)
                {
                    _character.TravelStart();
                }


                if (_character.activeState == NPCharacter.states.Travel && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
                {
                    _character.TravelEnd();
                    state = NodeState.SUCCESS;
                    return state;
                }
                #endregion
                break;

            case NPCharacter.states.Wander:
                #region Wander call
                if (_character.activeState != NPCharacter.states.Wander)
                {
                    _character.WanderStart();
                }


                if (_character.activeState == NPCharacter.states.Wander && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
                {
                    _character.WanderStart();
                    state = NodeState.SUCCESS;
                    return state;
                }
                #endregion
                break;

            case NPCharacter.states.Patrol:
                #region Patrol call
                if (_character.activeState != NPCharacter.states.Patrol)
                {
                    _character.PatrolStart();
                }


                if (_character.activeState == NPCharacter.states.Patrol && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
                {
                    _character.PatrolEnd();
                    state = NodeState.SUCCESS;
                    return state;
                }
                #endregion
                break;

        }

        state = NodeState.RUNNING;
        return state;
    }
}
