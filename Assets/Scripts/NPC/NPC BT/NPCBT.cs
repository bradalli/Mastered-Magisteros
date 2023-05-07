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
        new TaskDebugLog("Running act behaviour tree!")

        /* PSEUDO CODE
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
                        // new SetOwnerPositionTeleport(currentAction.location),
                        // new TaskTriggerAction(currentAction)
                    })
                })
            }),

            // new TaskTriggerAction(currentAction)
        })*/
    });

    Node moveTree = new Selector(new List<Node>
    {
        new TaskDebugLog("Running move behaviour tree!")
    });

    Node combatTree = new Selector(new List<Node>
    {
        new TaskDebugLog("Running combat behaviour tree!")
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
