using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class RepeatNode : DecoratorNode
    {
        #region Overrides of Node

        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            child.Update();
            return State.Running;
        }

        #endregion
    }
}

