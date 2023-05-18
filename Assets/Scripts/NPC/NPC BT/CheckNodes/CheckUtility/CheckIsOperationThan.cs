using Mastered.Magisteros.BT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsOperationThan : Node
{
    public enum operationTypes { GreaterThan, LessThan, EqualTo, GreaterOrEqual, LessOrEqual}
    public operationTypes _operation;
    public float _value1;
    public float _value2;

    public CheckIsOperationThan(float value1, operationTypes operation, float value2)
    {
        _value1 = value1;
        _operation = operation;
        _value2 = value2;
    }

    public override NodeState Evaluate()
    {
        switch (_operation)
        {
            case operationTypes.GreaterThan:
                if(_value1 > _value2)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
                break;

            case operationTypes.LessThan:
                if (_value1 < _value2)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
                break;

            case operationTypes.EqualTo:
                if (_value1 == _value2)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
                break;

            case operationTypes.GreaterOrEqual:
                if (_value1 >= _value2)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
                break;

            case operationTypes.LessOrEqual:
                if (_value1 <= _value2)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
                break;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
