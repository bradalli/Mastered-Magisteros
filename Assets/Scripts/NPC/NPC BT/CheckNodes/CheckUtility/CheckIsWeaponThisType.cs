using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsWeaponThisType : Node
{
    public Weapon _weapon;
    public Weapon.weaponTypes _type;

    public CheckIsWeaponThisType(Weapon weapon, Weapon.weaponTypes type)
    {
        _weapon = weapon;
        _type = type;
    }

    public override NodeState Evaluate()
    {
        if(_weapon.type == _type)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
