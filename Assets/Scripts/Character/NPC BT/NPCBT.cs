using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.BT;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.Actions;
using System;

[RequireComponent(typeof(NPCharacter))]
public class NPCBT : BehaviourTree
{
    #region Public variables

    public enum BehaviourTree { Act, Move, Combat}
    public BehaviourTree activeBehaviourTree = BehaviourTree.Act;

    #endregion

    #region Private variables
    public NPCharacter charSelf;
    #endregion

    #region Trees

    Node ActTree()
    {
        return new Selector(new List<Node>
    {
        new TaskDebugLog("Running act behaviour tree!"),

        // Idle Sequence
        new Sequence(new List<Node>
        {
            // new CheckIsActionNull(currentAction),
            new CheckIsActionThisType(charSelf.GetCurrCharAction(), CharacterAction.ActionType.Empty, false),
            // new TaskPlayAnimation("Idle")
            new TaskTriggerAction(charSelf)
        }),

        // Talk Sequence
        new Sequence(new List<Node>
        {
            // new CheckIsActionThisType(currentAction, "Talk"),
            new CheckIsActionThisType(charSelf.GetCurrCharAction(), CharacterAction.ActionType.Talk, false),
            // new TaskLookAtTarget(target),
            new TaskLookAtTarget(charSelf, charSelf.GetClosestCharacter().transform),

            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    // new CheckIsTargetThisType(target, "Player"),
                    new CheckIsCharacterThisType(charSelf, Personality.personalityTypes.Player),
                    // new TaskEnterDialogueWithPlayer(),
                    new TaskTriggerAction(charSelf),
                    // new TaskReturnToPreviousState(previousState)
                    new TaskSetCurrentAction(new CharacterAction(), charSelf),
                }),

                new Sequence(new List<Node>
                {
                    // new TaskEnterDialogueWithTarget(target),
                    new TaskTriggerAction(charSelf),
                    // new TaskReturnToPreviousState(previousState)
                    new TaskSetCurrentAction(new CharacterAction(), charSelf)
                })
            })
        }),

        // Task Sequence
        new Sequence(new List<Node>
        {
            new Sequence(new List<Node>
            {
                // new CheckActionHasLocation(currentAction),
                new CheckActionHasLocation(charSelf.GetCurrCharAction()),

                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        // new CheckIsOwnerInRange(transform.position, currentAction.location, maxRange),
                        new CheckIsOperationThan(Vector3.Distance(charSelf.transform.position, charSelf.GetCurrCharAction().location), 
                        CheckIsOperationThan.operationTypes.LessThan, charSelf.GetCurrCharAction().range),
                        // new TaskTriggerAction(currentAction)
                        new TaskTriggerAction(charSelf),
                    }),

                    new Sequence(new List<Node>
                    {
                        // new TaskSetOwnerPositionTeleport(currentAction.location),
                        new TaskSetCharacterPosition(charSelf, charSelf.GetCurrCharAction().location),
                        // new TaskTriggerAction(currentAction)
                        new TaskTriggerAction(charSelf),
                    })
                })
            }),

            // new TaskTriggerAction(currentAction)
            new TaskTriggerAction(charSelf),
        })
    });
    }

    Node MoveTree()
    {
        return new Selector(new List<Node>
        {
        new TaskDebugLog("Running move behaviour tree!"),

        new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                // new CheckIsXOperationThanX(waypoints.length, Operation.Greater, 0),
                new CheckIsOperationThan(charSelf.GetWaypointsLength(), CheckIsOperationThan.operationTypes.GreaterThan, 0),

                new Selector(new List<Node>
                {
                    // Patrol Sequence
                    new Sequence(new List<Node>
                    {
                        // new CheckIsXOperationThanX(waypoints.length, Operation.Less, 1),
                        new CheckIsOperationThan(charSelf.GetWaypointsLength(), CheckIsOperationThan.operationTypes.GreaterOrEqual, 1),

                        new Selector(new List<Node>
                        {
                            new Sequence(new List<Node>
                            {
                                // new CheckIsXOperationThanX(wpIndex, Operation.Less, waypoints.Length)
                                new CheckIsOperationThan(charSelf.GetCurrWpIndex(), CheckIsOperationThan.operationTypes.LessThan,
                                charSelf.GetWaypointsLength()),
                                // new TaskGoToPosition(waypoints(wpIndex).location),
                                new TaskGoToPosition(charSelf, charSelf.GetTargetWaypoint().location, NPCharacter.states.Patrol),
                                // new TaskIncrementWPIndex(),
                                new TaskSetWPIndex(charSelf, charSelf.GetCurrWpIndex() + 1),

                                new Sequence(new List<Node>
                                {
                                    // new CheckHasWPAnAction(waypoints(wpIndex)),
                                    new CheckIsActionThisType(charSelf.GetTargetWaypoint().action, CharacterAction.ActionType.Empty, true),
                                    // new TaskSetCurrentAction(waypoints(wpIndex).action),
                                    new TaskSetCurrentAction(charSelf.GetTargetWaypoint().action, charSelf),
                                    // new TaskSetParentState(actState)
                                    new TaskSetParentState(charSelf, BehaviourTree.Act),
                                })
                            }),

                            new Selector(new List<Node>
                            {
                                new Sequence(new List<Node>
                                {
                                    // new CheckIsWPMarkedLoop(waypoints(wpIndex)),
                                    new CheckIsOperationThan(Convert.ToSingle(charSelf.GetTargetWaypoint().isLoop), CheckIsOperationThan.operationTypes.EqualTo, 1),
                                    // new TaskSetWPIndex(0)
                                    new TaskSetWPIndex(charSelf, 0),
                                }),
                                
                                // new TaskSetParentState(actState)
                                new TaskSetParentState(charSelf, BehaviourTree.Act),
                            })
                        })
                    }),

                    // Wander Sequence
                    new Sequence(new List<Node>
                    {
                        // new CheckIsWanderX(true),
                        new CheckIsWpWander(charSelf.GetTargetWaypoint()),
                        // new TaskGoWander(waypoints(0))
                        new TaskWander(charSelf),
                    }),

                    // Travel Sequence
                    new Sequence(new List<Node>
                    {
                        // new TaskGoToPosition(waypoints(0).location),
                        new TaskGoToPosition(charSelf, charSelf.GetTargetWaypoint().location, NPCharacter.states.Travel),

                        new Sequence(new List<Node>
                        {
                            // new CheckHasWPAnAction(waypoints(wpIndex)),
                            new CheckIsActionThisType(charSelf.GetTargetWaypoint().action, CharacterAction.ActionType.Empty, true),
                            // new TaskSetCurrentAction(waypoints(wpIndex).action),
                            new TaskSetCurrentAction(charSelf.GetTargetWaypoint().action, charSelf),
                            // new TaskSetParentState(actState)
                            new TaskSetParentState(charSelf, BehaviourTree.Act),
                        })
                    })
                })
            }),

            // new TaskSetParentState(actState)
            new TaskSetParentState(charSelf, BehaviourTree.Act),
            })
        });
    }

    Node CombatTree()
    {
        return new Selector(new List<Node>
        {
        new TaskDebugLog("Running combat behaviour tree!"),

        new Selector(new List<Node>
        {
            // Death Sequence
            new Sequence(new List<Node>
            {
                // new CheckIsXOperationThanX(hp, Operation.Lesser, 1),
                // new TaskTriggerDeathState()
            }),

            // Flee Sequence
            new Sequence(new List<Node>
            {
                // new CheckIsXOperationThanX(hp, Operation.Lesser, hpFleeRange),

                new Selector(new List<Node>
                {
                    // new CheckIsXAlone(ownerCharAwareness),

                    new Sequence(new List<Node>
                    {
                        // new CheckIsXOperationThanX(hp, Operation.Lesser, hpWoundedRange),
                        // new TaskSetMoveSpeed(moveSpeedWounded)
                    })
                }),

                // new TaskFleeTarget(target)
            }),

            // Ranged Attack Sequence
            new Sequence(new List<Node>
            {
                // new CheckIsWeaponXTypeX(mainWeapon, WeaponType.Ranged),

                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        // new CheckIsXInRangeToX(target, owner, rangedAttackDistane),
                        // new CheckIsXOperationThanX(itemType.Arrow.Count, Operation.Greater, 0),
                        
                        new Sequence(new List<Node>
                        {
                            // new CheckHasTimeSinceXBeenX(timeLastAttack, delayRangedAttack),
                            // new TaskAttackTarget(target, AttackType.Ranged)
                        })
                    }),

                    // new TaskSetMainWeapon(WeaponType.Melee)
                })
            }),

            // Melee Attack Sequence
            new Sequence(new List<Node>
            {
                // new CheckIsWeaponXTypeX(mainWeapon, WeaponType.Melee),

                new Selector(new List<Node>
                {
                    // Evade Sequence
                    new Sequence(new List<Node>
                    {
                        new Sequence(new List<Node>
                        {
                            // new CheckIsXOperationThanX(timeLastAttack, Operation.Lesser, delayMeleeAttack, WaitMode.Until),
                            // new TaskMaintainDistanceFromTarget(target, evadeDistance)
                        }),
                    }),

                    // Contact Sequence
                    new Sequence(new List<Node>
                    {
                        // new TaskMaintainDistanceFromTarget(target, attackDistance),

                        new Selector(new List<Node>
                        {
                            // Block Sequence
                            new Sequence(new List<Node>
                            {
                                // new CheckIsTargetAttackingOwner(target),
                                // new TaskWaitForSeconds(Random.Range(delayBlockReactionMin, delayBlockReactionMax)),

                                new Selector(new List<Node>
                                {
                                    new Sequence(new List<Node>
                                    {
                                        // new CheckHasOwnerBeenAttacked(),
                                        // new TaskBlock()
                                    }),
                                })
                            }),

                            // Attack Sequence
                            new Sequence(new List<Node>
                            {
                                // new CheckIsXInRangeToX(target, owner, meleeAttackDistance),

                                new Selector(new List<Node>
                                {
                                    new Sequence(new List<Node>
                                    {
                                        // new CheckIsAttackSuccessfull(),
                                        // new TaskAttackTarget(target)
                                    }),

                                    // new TaskOwnerIsStaggered()
                                })
                            })
                        })
                    }),
                })
            })
        })
        });
    }

    #endregion

    #region Behaviour Tree Overrides
    Node root;
    protected override Node SetupTree()
    {
        root = null;

        switch (activeBehaviourTree)
        {
            case BehaviourTree.Act:
                root = ActTree();
                break;

            case BehaviourTree.Move:
                root = MoveTree();
                break;

            case BehaviourTree.Combat:
                root = CombatTree();
                break;

            default:
                root = ActTree();
                break;
        }

        return root;
    }

    #endregion

    #region Custom methods

    public void ChangeTree(BehaviourTree newState)
    {
        activeBehaviourTree = newState;
        reset = true;
        root = null;
        SetupTree();
    }

    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        charSelf = GetComponent<NPCharacter>();
    }
    #endregion
}
