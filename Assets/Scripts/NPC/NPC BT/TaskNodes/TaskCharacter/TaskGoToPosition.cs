using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskGoToPosition : Node
{
    public NavMeshAgent _ownerNavMeshAgent;
    public Vector3 _desiredPosition;

    public TaskGoToPosition(NavMeshAgent ownerNavMeshAgent, Vector3 desiredPosition)
    {
        _ownerNavMeshAgent = ownerNavMeshAgent;
        _desiredPosition = desiredPosition;
    }

    public override NodeState Evaluate()
    {
        if (!_ownerNavMeshAgent.isOnOffMeshLink)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (_ownerNavMeshAgent.destination != _desiredPosition)
            _ownerNavMeshAgent.SetDestination(_desiredPosition);

        if (Vector3.Distance(_ownerNavMeshAgent.transform.position, _desiredPosition) < 0.05f)
        {
            state = NodeState.RUNNING;
        }

        else
        {
            state = NodeState.SUCCESS;
        }

        return state;
    }
}
