using Mastered.Magisteros.Actions;
using Mastered.Magisteros.NPC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCBT))]
public class NPCharacter : CharacterCore
{
    #region Private varaibles
    private NPCBT behaviourTree;
    private Transform meshParentTransform;
    #endregion

    #region Public variables

    [Header("Character Profile")]
    public CharacterProfile profile;
    public string characterName = "NotYetAssigned";
    public UnityEngine.Object meshPrefab = null;
    public enum stateStatus { Entering, Running, Exiting}
    public stateStatus activeStateStatus;
    public enum states { Idle, Talk, Act, Patrol, Wander, Travel, Die, Flee, RangeAttack, 
        MeleeEvade, MeleeContact, MeleeBlock, MeleeAttack, Stagger, EquippingWeapon, ChangingParentState, Wait, SetWpIndex}
    public states activeState = states.Idle;
    #endregion

    #region Event Actions
    // Miscellaneous
    public event Action<NPCBT.BehaviourTree> onSetParentStateStart, onSetParentStateEnd;
    public event Action<float> onWaitForSecondsStart, onWaitForSecondsEnd;
    public event Action<int> onSetWpIndexStart, onSetWpIndexEnd;

    // Acting
    public event Action onIdleStart, onIdleEnd;
    public event Action onTalkStart, onTalkEnd;
    public event Action onActStart, onActEnd;

    // Movement
    public event Action onPatrolStart, onPatrolEnd;
    public event Action onWanderStart, onWanderEnd;
    public event Action onTravelStart, onTravelEnd;

    // Combat
    public event Action onDieStart, onDieEnd;
    public event Action<CharacterCore, float> onFleeStart, onFleeEnd;
    public event Action onRangeAttackStart, onRangeAttackEnd;
    public event Action<CharacterCore, float> onMeleeEvadeStart, onMeleeEvadeEnd;
    public event Action onMeleeContactStart, onMeleeContactEnd;
    public event Action onMeleeBlockStart, onMeleeBlockEnd;
    public event Action onMeleeAttackStart, onMeleeAttackEnd;
    public event Action onStaggerStart, onStaggerEnd;

    public event Action<Weapon> onEquipWeaponStart, onEquipWeaponEnd;
    #endregion

    #region Delegates
    public delegate bool BoolCheck();
    public BoolCheck checkIsInCombat;
    public BoolCheck checkAreWaypointsRemaining;
    public BoolCheck checkIsAnActionBeingPerfomed;

    public delegate Personality.personalityTypes PersonalityCheck();
    public PersonalityCheck checkPersonality;

    public delegate CharacterCore CharacterCheck();
    public CharacterCheck checkCombatTargetChar;
    public CharacterCheck checkClosestChar;

    public delegate CharacterAction CharActionCheck();
    public CharActionCheck checkCurrCharAction;

    public delegate int IntCheck();
    public IntCheck checkWaypointsLength;
    public IntCheck checkCurrWaypointIndex;

    public delegate Vector3 Vec3Check();
    public Vec3Check checkTargetLocation;
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
    // Miscellaneous
    public void SetParentStateStart(NPCBT.BehaviourTree newTree) => onSetParentStateStart?.Invoke(newTree);
    public void SetParentStateEnd(NPCBT.BehaviourTree newTree) => onSetParentStateEnd?.Invoke(newTree);
    public void WaitForSecondsStart(float seconds) => onWaitForSecondsStart?.Invoke(seconds);
    public void WaitForSecondsEnd(float seconds) => onWaitForSecondsEnd?.Invoke(seconds);
    public void SetWpIndexStart(int index) => onSetWpIndexStart?.Invoke(index);
    public void SetWpIndexEnd(int index) => onSetWpIndexEnd?.Invoke(index);

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
    public void FleeStart(CharacterCore fleeFromChar, float desiredDist) => onFleeStart?.Invoke(fleeFromChar, desiredDist);
    public void FleeEnd(CharacterCore fleeFromChar, float desiredDist) => onFleeEnd?.Invoke(fleeFromChar, desiredDist);
    public void RangeAttackStart() => onRangeAttackStart?.Invoke();
    public void RangeAttackEnd() => onRangeAttackEnd?.Invoke();
    public void MeleeEvadeStart(CharacterCore evadeChar, float desiredDist) => onMeleeEvadeStart?.Invoke(evadeChar, desiredDist);
    public void MeleeEvadeEnd(CharacterCore evadeChar, float desiredDist) => onMeleeEvadeEnd?.Invoke(evadeChar, desiredDist);
    public void MeleeContactStart() => onMeleeContactStart?.Invoke();
    public void MeleeContactEnd() => onMeleeContactEnd?.Invoke();
    public void MeleeBlockStart() => onMeleeBlockStart?.Invoke();
    public void MeleeBlockEnd() => onMeleeBlockEnd?.Invoke();
    public void MeleeAttackStart() => onMeleeAttackStart?.Invoke();
    public void MeleeAttackEnd() => onMeleeAttackEnd?.Invoke();
    public void StaggerStart() => onStaggerStart?.Invoke();
    public void StaggerEnd() => onStaggerEnd?.Invoke();

    public void EquipWeaponStart(Weapon newWeapon) => onEquipWeaponStart?.Invoke(newWeapon);
    public void EquipWeaponEnd(Weapon newWeapon) => onEquipWeaponEnd?.Invoke(newWeapon);
    #endregion

    #region Delegate check methods
    public override bool IsInCombat() => checkIsInCombat.Invoke();
    public bool AreWaypointsRemaining() => checkAreWaypointsRemaining.Invoke();
    public bool IsAnActionBeingPerfomed() => checkIsAnActionBeingPerfomed.Invoke();
    public Personality.personalityTypes GetPersonality() => checkPersonality.Invoke();
    public CharacterCore GetCombatTargetChar() => checkCombatTargetChar.Invoke();
    public CharacterCore GetClosestCharacter() => checkClosestChar.Invoke();
    public CharacterAction GetCurrCharAction() => checkCurrCharAction.Invoke();
    public int GetWaypointsLength() => checkWaypointsLength.Invoke();
    public int GetCurrWpIndex() => checkCurrWaypointIndex.Invoke();
    public Vector3 GetTargetLocation() => checkTargetLocation.Invoke();
    #endregion

    #endregion
}
