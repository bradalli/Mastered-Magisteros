using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.BT;

public class GuardBT : BehaviourTree
{
    public Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform)
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform)
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
