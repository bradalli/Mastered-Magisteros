using Mastered.Magisteros.NPC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCBT))]
public class NPCharacter : CharacterCore
{
    private NPCBT behaviourTree;
    [Header("Character Profile")]
    public CharacterProfile profile;
    public string characterName = "NotYetAssigned";
    public UnityEngine.Object meshPrefab = null;
    Transform meshParentTransform;

    public enum stateStatus { Entering, Running, Exiting}
    public stateStatus activeStateStatus;

    public enum states { Idle, Talk, Act, Patrol, Wander, Travel, Die, Flee, RangeAttack, 
        MeleeEvade, MeleeContact, MeleeBlock, MeleeAttack, Stagger }
    public states activeState = states.Idle;

    #region Event Actions
    //Acting
    public event Action onIdleStart, onIdleEnd;
    public event Action onTalkStart, onTalkEnd;
    public event Action onActStart, onActEnd;

    //Movement
    public event Action onPatrolStart, onPatrolEnd;
    public event Action onWanderStart, onWanderEnd;
    public event Action onTravelStart, onTravelEnd;

    //Combat
    public event Action onDieStart, onDieEnd;
    public event Action onFleeStart, onFleeEnd;
    public event Action onRangeAttackStart, onRangeAttackEnd;
    public event Action onMeleeEvadeStart, onMeleeEvadeEnd;
    public event Action onMeleeContactStart, onMeleeContactEnd;
    public event Action onMeleeBlockStart, onMeleeBlockEnd;
    public event Action onMeleeAttackStart, onMeleeAttackEnd;
    public event Action onStaggerStart, onStaggerEnd;
    #endregion

    #region Delegates
    public delegate bool BoolCheck();
    public BoolCheck checkIsInCombat;

    public delegate Personality.personalityTypes PersonalityCheck();
    public PersonalityCheck checkPersonality;

    public delegate CharacterCore CharacterCheck();
    public CharacterCheck checkCombatTargetChar;
    #endregion

    #region MonoBehaviour Methods
    private void Awake()
    {
        meshParentTransform = transform.Find("Mesh");
        TryGetComponent<NPCBT>(out behaviourTree);
    }

    [ExecuteInEditMode]
    private void OnValidate()
    {
        meshParentTransform = transform.Find("Mesh");

        transform.name = $"NPC - {characterName}";
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + Vector3.up, new Vector3(1, 2, 1));
    }
    #endregion

    #region Custom Methods

    #region Event action Methods
    // Acting
    public void IdleStart() => onIdleStart?.Invoke(); 
    public void IdleEnd() => onIdleEnd?.Invoke();
    public void TalkStart() => onTalkStart?.Invoke();
    public void TalkEnd() => onTalkEnd?.Invoke();
    public void ActStart() => onActStart?.Invoke();
    public void ActEnd() => onActEnd?.Invoke();

    // Movement
    public void PatrolStart() => onPatrolStart?.Invoke();
    public void PatrolEnd() => onPatrolEnd?.Invoke();
    public void WanderStart() => onWanderStart?.Invoke();
    public void WanderEnd() => onWanderEnd?.Invoke();
    public void TravelStart() => onTravelStart?.Invoke();
    public void TravelEnd() => onTravelEnd?.Invoke();

    // Combat
    public void DieStart() => onDieStart?.Invoke();
    public void DieEnd() => onDieEnd?.Invoke();
    public void FleeStart() => onFleeStart?.Invoke();
    public void FleeEnd() => onFleeEnd?.Invoke();
    public void RangeAttackStart() => onRangeAttackStart?.Invoke();
    public void RangeAttackEnd() => onRangeAttackEnd?.Invoke();
    public void MeleeEvadeStart() => onMeleeEvadeStart?.Invoke();
    public void MeleeEvadeEnd() => onMeleeEvadeEnd?.Invoke();

    #endregion

    #region Delegate check methods
    public override bool IsInCombat() => checkIsInCombat.Invoke();
    public Personality.personalityTypes GetPersonality() => checkPersonality.Invoke();
    public CharacterCore GetCombatTargetChar() => checkCombatTargetChar.Invoke();

    internal bool AreWaypointsRemaining()
    {
        throw new NotImplementedException();
    }

    internal bool IsATaskBeingPerformed()
    {
        throw new NotImplementedException();
    }
    #endregion

    #endregion
}
