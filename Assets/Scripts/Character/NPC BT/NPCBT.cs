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
        return new Selector();
    }

    Node MoveTree()
    {
        return new Selector();
    }

    Node CombatTree()
    {
        return new Selector();
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
