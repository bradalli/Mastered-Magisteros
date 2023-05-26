using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskMaintainDistanceFromChar : Node
{
    //public NavMeshAgent _ownerNavMeshAgent;
    public CharacterCombat _targetCharCombat;
    //public float _desiredDistance;

    private bool nodeEntered;

    public TaskMaintainDistanceFromChar(NavMeshAgent ownerNavMeshAgent, CharacterCombat targetCharacter, float desiredDistance)
    {
        //_ownerNavMeshAgent = ownerNavMeshAgent;
        _targetCharCombat = targetCharacter;
        //_desiredDistance = desiredDistance;
    }

    public override NodeState Evaluate()
    {
        /*
        // Calculate vector and position away from the target character by the desired distance.
        Vector3 towardVector = Vector3.Normalize(_targetCharCombat.transform.position - _ownerNavMeshAgent.transform.position);
        Vector3 targetDestination = _targetCharCombat.transform.position +
            new Vector3(towardVector.x * _desiredDistance, _ownerNavMeshAgent.transform.position.y, towardVector.z * _desiredDistance);

        if (Vector3.Distance(_ownerNavMeshAgent.transform.position, targetDestination) > _desiredDistance)
        {
            //If the targetDestination has changed, update it.
            if (_ownerNavMeshAgent.destination != targetDestination)
                _ownerNavMeshAgent.SetDestination(targetDestination);
            
            state = NodeState.RUNNING;
        }

        else
        {
            state = NodeState.SUCCESS;
        }

        return state;
        */

        if(!nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.MaintainingDistance)
        {
            nodeEntered = true;
            _targetCharCombat.MaintainDistance();
            state = NodeState.RUNNING;
            return state;
        }

        if(nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.MaintainingDistance)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
