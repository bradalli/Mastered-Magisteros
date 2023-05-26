using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskLookAtTarget : Node
{
    public Mastered.Magisteros.NPC.CharacterCombat _character;
    public Transform _targetTransform;

    public TaskLookAtTarget(Mastered.Magisteros.NPC.CharacterCombat character, Transform targetTransform)
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
