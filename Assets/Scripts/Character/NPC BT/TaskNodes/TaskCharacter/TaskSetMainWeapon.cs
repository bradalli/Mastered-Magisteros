using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TaskSetMainWeapon : Node
{
    public NPCharacter _character;
    public Weapon _newWeapon;

    public TaskSetMainWeapon(NPCharacter character, Weapon newWeapon)
    {
        _character = character;
        _newWeapon = newWeapon;
    }

    public override NodeState Evaluate()
    {
        if (_character.activeState != NPCharacter.states.EquippingWeapon)
        {
            _character.EquipWeaponStart(_newWeapon);
        }


        if (_character.activeState == NPCharacter.states.EquippingWeapon && _character.activeStateStatus == NPCharacter.stateStatus.Exiting)
        {
            _character.EquipWeaponEnd(_newWeapon);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
