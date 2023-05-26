using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLookAtTarget : Node
{
    public Character _character;
    public Transform _targetTransform;

    public TaskLookAtTarget(Character character, Transform targetTransform)
    {
        _character = character;
        _targetTransform = targetTransform;
    }

    public override NodeState Evaluate()
    {
        _character.viewTarget = _targetTransform;

        state = NodeState.SUCCESS;
        return state;
    }
}
