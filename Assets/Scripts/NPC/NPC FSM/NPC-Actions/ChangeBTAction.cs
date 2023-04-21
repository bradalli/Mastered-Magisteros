using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mastered.Magisteros.FSM;
using TheKiwiCoder;

[CreateAssetMenu(menuName = "FSM/Actions/ChangeBTAction")]
public class ChangeBTAction : FSMAction
{
    public BehaviourTree newTree;
    public override void Execute(BaseStateMachine stateMachine)
    {
        var behaviourTreeRunner = stateMachine.GetComponent<BehaviourTreeRunner>();
        if (behaviourTreeRunner.tree == null ^ behaviourTreeRunner.tree.GetType() != newTree.GetType())
        {
            Debug.Log($"Behaviour tree has changed from {behaviourTreeRunner.tree.name} to {newTree.name} at... {Time.time}");
            behaviourTreeRunner.tree = Instantiate(newTree) as BehaviourTree;
        } 
    }
}