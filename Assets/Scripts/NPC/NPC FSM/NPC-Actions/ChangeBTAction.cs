using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.BTwGraph;

[CreateAssetMenu(menuName = "FSM/Actions/ChangeBTAction")]
public class ChangeBTAction : FSMAction
{
    public BehaviourTree newTree;
    public override void Execute(BaseStateMachine stateMachine)
    {
        var behaviourTreeRunner = stateMachine.GetComponent<BehaviourTreeRunner>();
        if (behaviourTreeRunner.lastTree != newTree)
        {
            Debug.Log($"Behaviour tree has changed from {behaviourTreeRunner.tree.name} to {newTree.name} at... {Time.time}");
            behaviourTreeRunner.tree = newTree.Clone();
            behaviourTreeRunner.lastTree = newTree;
        }
    }
}