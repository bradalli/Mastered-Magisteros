using Mastered.Magisteros.BT;
using Mastered.Magisteros.NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsCharAttackSuccess : Node
{
    private Character _character;
    private float _timeLastGivenAttack;
    private Character _charLastGivenAttack;

    public CheckIsCharAttackSuccess(Character character, float timeLastGivenAttack, Character charLastGivenAttack)
    {
        _character = character;
        _timeLastGivenAttack = timeLastGivenAttack;
        _charLastGivenAttack = charLastGivenAttack;
    }

    public override NodeState Evaluate()
    {
        if(_charLastGivenAttack.charLastReceivedAttack == _character)
        {
            if(_charLastGivenAttack.timeLastReceivedAttack == _timeLastGivenAttack)
            {
                state = NodeState.SUCCESS;
                return state;
            }
        }

        state = NodeState.FAILURE;
        return state;
    }
}
