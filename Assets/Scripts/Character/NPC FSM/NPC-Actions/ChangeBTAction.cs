using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mastered.Magisteros.FSM;
using Mastered.Magisteros.BTwGraph;

[CreateAssetMenu(menuName = "FSM/Actions/ChangeBTAction")]
public class ChangeBTAction : FSMAction
{
    public NPCBT.BehaviourTree newTree;
    public override void Execute(BaseStateMachine stateMachine)
    {
        var behaviourTreeRunner = stateMachine.GetComponent<NPCBT>();
        if (behaviourTreeRunner.activeBehaviourTree != newTree)
        {
            Debug.Log($"Behaviour tree has changed from {behaviourTreeRunner.activeBehaviourTree} to {newTree} at... {Time.time}");
            behaviourTreeRunner.ChangeTree(newTree);
        }
    }
}