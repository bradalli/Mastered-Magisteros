using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetCharacterPosition : Node
{
    public CharacterCore _targetCharacter;
    public Vector3 _targetPosition;

    public TaskSetCharacterPosition(CharacterCore targetCharacter, Vector3 targetPosition)
    {
        _targetCharacter = targetCharacter;
        _targetPosition = targetPosition;
    }

    public override NodeState Evaluate()
    {
        _targetCharacter.transform.position = _targetPosition;

        state = NodeState.SUCCESS;
        return state;
    }
}
