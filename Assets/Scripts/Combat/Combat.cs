using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public enum combatState { Idle, Waiting, Attacking, Blocking, Staggered, Fleeing, Wounded, Dying}
    public combatState currentState = combatState.Idle;
}
