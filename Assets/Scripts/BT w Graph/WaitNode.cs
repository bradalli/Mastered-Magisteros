using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class WaitNode : ActionNode
    {
        public float duration = 1f;

        private float startTime;

        #region Overrides of Node

        protected override void OnStart() => startTime = Time.time;

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            return Time.time - startTime > duration ? State.Success : State.Running;
        }

        #endregion
    }
}

