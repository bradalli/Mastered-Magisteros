using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.NPC;

public class CharacterCombat : MonoBehaviour
{
    #region Public Variables
    [Header("State Information")]
    public combatState currentState = combatState.Idle;
    public enum combatState { Idle, MaintainingDistance, Attacking, Blocking, Staggered, Fleeing, Wounded, Dead }

    [Header("Attacking")]
    //public bool attemptAttack;
    //public bool isAttacking;
    public Mastered.Magisteros.NPC.CharacterCombat combatTarget;
    public float timeLastGivenAttack;
    public Mastered.Magisteros.NPC.CharacterCombat charLastGivenAttack;
    public float timeLastReceivedAttack;
    public Mastered.Magisteros.NPC.CharacterCombat charLastReceivedAttack;

    [Header("Blocking")]
    //public bool attemptBlock;
    //public bool isBlocking;

    [Header("Staggered State")]
    //public bool isStaggered;
    public float staggeredLength;
    #endregion

    #region Private Variables
    private float staggeredStartTime;
    private float staggeredTime;
    #endregion

    #region Custom Methods
    public void AttackTarget()
    {
        currentState = combatState.Attacking;
    }

    public void Block()
    {
        currentState = combatState.Blocking;
    }

    public void Stagger()
    {
        currentState = combatState.Staggered;
    }

    public void MaintainDistance()
    {
        currentState = combatState.MaintainingDistance;
    }

    public void Flee()
    {
        currentState = combatState.Fleeing;
    }
    #endregion

    #region Coroutines

    #endregion
}
