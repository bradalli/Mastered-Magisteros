using Mastered.Magisteros.NPC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCBT))]
//[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterAwareness))]
[RequireComponent(typeof(CharacterCombat))]
[RequireComponent(typeof(CharacterActor))]
//[RequireComponent(typeof(ItemContainer))]
//[RequireComponent(typeof(CharacterEquipment))]
public class NPCharacter : CharacterCore
{
    public enum Personality { Friendly, Hostile, Fearful }

    [Header("Character Profile")]
    public CharacterProfile profile;
    public Personality personality = Personality.Friendly;
    public string characterName = "NotYetAssigned";
    public UnityEngine.Object meshPrefab = null;
    Transform meshParentTransform;

    public enum actingStates { Idle, Talk, Act}
    public actingStates currentActState = actingStates.Idle;

    public enum movementStates { Patrol, Wander, Travel}
    public movementStates currentMoveState = movementStates.Travel;

    public enum combatStates { Die, Flee, RangeAttack, MeleeEvade, MeleeContact, MeleeBlock, MeleeAttack, Stagger}
    public combatStates currentCombatState = combatStates.MeleeContact;

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

    private void Awake()
    {
        meshParentTransform = transform.Find("Mesh");
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
}
