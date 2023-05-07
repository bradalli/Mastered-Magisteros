using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mastered.Magisteros.BT;

public class TaskDebugLog : Node
{
    private string _message;

    public TaskDebugLog(string message)
    {
        _message = message;
    }

    public override NodeState Evaluate()
    {
        Debug.Log($"TaskDebugLog: {_message}");

        state = NodeState.RUNNING;
        return state;
    }
}
