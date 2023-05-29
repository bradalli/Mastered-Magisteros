using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.NPC;
using UnityEngine.Events;

public class CharacterCombat : CharacterCore
{
    #region MonoBehaviour
    private void Awake()
    {

    }

    #endregion

    #region Public Variables
    [Header("Overview Information")]
    public Personality.personalityTypes personality = Personality.personalityTypes.Friendly;
    public Weapon equipedWeapon;

    [Header("Attacking")]
    //public bool attemptAttack;
    //public bool isAttacking;
    public CharacterCore combatTarget;
    public float timeLastGivenAttack;
    public CharacterCore charLastGivenAttack;
    public float timeLastReceivedAttack;
    public CharacterCore charLastReceivedAttack;

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
    
    #endregion

    #region Coroutines

    #endregion
}
