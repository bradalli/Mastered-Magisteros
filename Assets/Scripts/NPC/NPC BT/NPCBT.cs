using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.BT;
using Mastered.Magisteros.FSM;

public class NPCBT : BehaviourTree
{
    #region Public variables

    public enum BehaviourTree { Act, Move, Combat}
    public BehaviourTree activeBehaviourTree = BehaviourTree.Act;

    #endregion

    #region Trees

    Node actTree = new Selector(new List<Node>
    {
        new TaskDebugLog("Running act behaviour tree!"),

        // Idle Sequence
        new Sequence(new List<Node>
        {
            // new CheckIsActionNull(currentAction),
            // new TaskPlayAnimation("Idle")
        }),

        // Talk Sequence
        new Sequence(new List<Node>
        {
            // new CheckIsActionThisType(currentAction, "Talk"),
            // new TaskLookAtTarget(target),
            new Selector(new List<Node>
            { 
                new Sequence(new List<Node>
                {
                    // new CheckIsTargetThisType(target, "Player"),
                    // new TaskEnterDialogueWithPlayer(),
                    // new TaskReturnToPreviousState(previousState)
                }),

                new Sequence(new List<Node>
                {
                    // new TaskEnterDialogueWithTarget(target),
                    // new TaskReturnToPreviousState(previousState)
                })
            })
        }),

        // Task Sequence
        new Sequence(new List<Node>
        {
            new Sequence(new List<Node>
            {
                // new CheckActionHasLocation(currentAction),

                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        // new CheckIsOwnerInRange(transform.position, currentAction.location, maxRange),
                        // new TaskTriggerAction(currentAction)
                    }),

                    new Sequence(new List<Node>
                    {
                        // new TaskSetOwnerPositionTeleport(currentAction.location),
                        // new TaskTriggerAction(currentAction)
                    })
                })
            }),

            // new TaskTriggerAction(currentAction)
        })
    });

    Node moveTree = new Selector(new List<Node>
    {
        new TaskDebugLog("Running move behaviour tree!"),

        new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                // new CheckIsXOperationThanX(waypoints.length, Operation.Greater, 0),

                new Selector(new List<Node>
                {
                    // Patrol Sequence
                    new Sequence(new List<Node>
                    {
                        // new CheckIsXOperationThanX(waypoints.length, Operation.Less, 0),

                        new Selector(new List<Node>
                        {
                            new Sequence(new List<Node>
                            {
                                // new CheckIsXOperationThanX(wpIndex, Operation.Less, waypoints.Length)
                                // new TaskGoToPosition(waypoints(wpIndex).location),
                                // new TaskIncrementWPIndex(),

                                new Sequence(new List<Node>
                                {
                                    // new CheckHasWPAnAction(waypoints(wpIndex)),
                                    // new TaskSetCurrentAction(waypoints(wpIndex).action),
                                    // new TaskSetParentState(actState)
                                })
                            }),

                            new Selector(new List<Node>
                            {
                                new Sequence(new List<Node>
                                {
                                    // new CheckIsWPMarkedLoop(waypoints(wpIndex)),
                                    // new TaskSetWPIndex(0)
                                }),
                                
                                // new TaskSetParentState(actState)
                            })
                        })
                    }),

                    // Wander Sequence
                    new Sequence(new List<Node>
                    {
                        // new CheckIsWanderX(true),
                        // new TaskGoWander(waypoints(0))
                    }),

                    // Travel Sequence
                    new Sequence(new List<Node>
                    {
                        // new TaskGoToPosition(waypoints(0).location),

                        new Sequence(new List<Node>
                        {
                            // new CheckHasWPAnAction(waypoints(wpIndex)),
                            // new TaskSetCurrentAction(waypoints(wpIndex).action),
                            // new TaskSetParentState(actState)
                        })
                    })
                })
            }),

            // new TaskSetParentState(actState)
        })
    });

    Node combatTree = new Selector(new List<Node>
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

    #endregion

    #region Behaviour Tree Overrides
    Node root;
    protected override Node SetupTree()
    {
        root = null;

        switch (activeBehaviourTree)
        {
            case BehaviourTree.Act:
                root = actTree;
                break;

            case BehaviourTree.Move:
                root = moveTree;
                break;

            case BehaviourTree.Combat:
                root = combatTree;
                break;

            default:
                root = actTree;
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
}
