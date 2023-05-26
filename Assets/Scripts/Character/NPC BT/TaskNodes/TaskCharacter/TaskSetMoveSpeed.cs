using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetMoveSpeed : Node
{
    public CharacterCore _targetCharacter;
    public float _newSpeed;

    public TaskSetMoveSpeed(CharacterCore targetCharacter, float newSpeed)
    {
        _targetCharacter = targetCharacter;
        _newSpeed = newSpeed;
    }

    public override NodeState Evaluate()
    {
        _targetCharacter.SetMoveSpeed(_newSpeed);
        state = NodeState.SUCCESS;
        return state;
    }
}
