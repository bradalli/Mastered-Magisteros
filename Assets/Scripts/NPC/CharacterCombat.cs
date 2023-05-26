using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.NPC;

public interface ICombat
{
    void AttackTarget();
    void Block();
    void Stagger();
    void Flee();
}

public class CharacterCombat : MonoBehaviour, ICombat
{
    #region Public Variables
    [Header("Overview Information")]
    public combatState currentState = combatState.Idle;
    public enum combatState { Idle, MaintainingDistance, EquipingWeapon, Attacking, Blocking, Staggered, Fleeing, Wounded, Dead }
    public Weapon equipedWeapon;

    [Header("Attacking")]
    //public bool attemptAttack;
    //public bool isAttacking;
    public Character combatTarget;
    public float timeLastGivenAttack;
    public Character charLastGivenAttack;
    public float timeLastReceivedAttack;
    public Character charLastReceivedAttack;

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
    public void MaintainDistance()
    {
        currentState = combatState.MaintainingDistance;
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        currentState = combatState.EquipingWeapon;
        equipedWeapon = newWeapon;
    }

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

    public void Flee()
    {
        currentState = combatState.Fleeing;
    }
    #endregion

    #region Coroutines

    #endregion
}
