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
        MeleeEvade, MeleeContact, MeleeBlock, MeleeAttack, Stagger, EquippingWeapon }
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
