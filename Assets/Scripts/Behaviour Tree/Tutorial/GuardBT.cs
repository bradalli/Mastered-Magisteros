using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.BT;

public class GuardBT : BehaviourTree
{
    public Transform[] waypoints;

    public static float speed = 2f;

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);
        return root;
    }
}
