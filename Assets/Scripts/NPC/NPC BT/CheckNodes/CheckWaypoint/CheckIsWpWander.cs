using Mastered.Magisteros.BT;
using Mastered.Magisteros.Waypoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsWpWander : Node
{
    public Waypoint _waypoint;

    public CheckIsWpWander(Waypoint waypoint)
    {
        _waypoint = waypoint;
    }

    public override NodeState Evaluate()
    {
        if (_waypoint.isWander)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
