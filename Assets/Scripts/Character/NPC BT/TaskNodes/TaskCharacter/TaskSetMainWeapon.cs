using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSetMainWeapon : Node
{
    public CharacterCombat _targetCharCombat;
    public Weapon _newWeapon;
    private bool nodeEntered;

    public TaskSetMainWeapon(CharacterCombat targetCharCombat, Weapon newWeapon)
    {
        _targetCharCombat = targetCharCombat;
        _newWeapon = newWeapon;
    }

    public override NodeState Evaluate()
    {
        if (!nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.EquipingWeapon)
        {
            nodeEntered = true;
            _targetCharCombat.EquipWeapon(_newWeapon);
            state = NodeState.RUNNING;
            return state;
        }

        if (nodeEntered && _targetCharCombat.currentState != CharacterCombat.combatState.EquipingWeapon)
        {
            nodeEntered = false;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
