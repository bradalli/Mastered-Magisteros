using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mastered.Magisteros.BT;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class TaskAttack : Node
{
    private Transform _lastTarget;
    //private EnemyManager _enemyManager;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    public TaskAttack(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        Debug.Log("Here");
        Transform target = (Transform)GetData("target");
        if(target != _lastTarget)
        {
            _lastTarget = target;
        }

        _attackCounter += Time.deltaTime;
        if(_attackCounter >= _attackTime)
        {
            Debug.Log("Enemy hit!");
            _attackCounter = 0f;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
