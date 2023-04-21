using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class FallBackNode : CompositeNode
    {
        private int current;

        #region Overrides of Node

        protected override void OnStart()
        {
            current = 0;
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            if (children is { Count: >= 1 })
                return children[current]!.Update() switch
                {
                    State.Running => State.Running,
                    State.Failure => ++current == children.Count ? State.Success : State.Running,
                    State.Success => State.Success,
                    _ => State.Failure
                };
            Debug.LogWarning("FallBack Node has no children.");
            return State.Failure;
        }

        #endregion
    }
}

