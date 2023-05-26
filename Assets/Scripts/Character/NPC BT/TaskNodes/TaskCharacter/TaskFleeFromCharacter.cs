using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskFleeFromCharacter : Node
{
    //public NavMeshAgent _ownerNavMeshAgent;
    public CharacterCombat _targetCharCombat;
    //public float _desiredDistance;

    private bool nodeEntered;

    public TaskFleeFromCharacter(NavMeshAgent ownerNavMeshAgent, CharacterCombat targetCharCombat, float desiredDistance)
    {
        //_ownerNavMeshAgent = ownerNavMeshAgent;
        _targetCharCombat = targetCharCombat;
        //_desiredDistance = desiredDistance;
    }

    public override NodeState Evaluate()
    {
        /*
        // Calculate vector and position away from the target character by the desired distance.
        Vector3 fleeVector = Vector3.Normalize(_ownerNavMeshAgent.transform.position - _targetCharacter.transform.position);
        Vector3 targetDestination = _targetCharacter.transform.position +
            new Vector3(fleeVector.x * _desiredDistance, _ownerNavMeshAgent.transform.position.y, fleeVector.z * _desiredDistance);

        if(Vector3.Distance(_ownerNavMeshAgent.transform.position, targetDestination) < _desiredDistance)
        {
            //If the targetDestination has changed, update it.
            if(_ownerNavMeshAgent.destination != targetDestination)
                _ownerNavMeshAgent.SetDestination(targetDestination);

            state = NodeState.RUNNING;
        }

        else
        {
            state = NodeState.SUCCESS;
        }

        return state;*/

        if (!nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Fleeing)
        {
            nodeEntered = true;
            _targetCharCombat.Flee();
            state = NodeState.RUNNING;
            return state;
        }

        if (nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.Fleeing)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
