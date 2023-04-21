using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class IsTaskLocationInRange : ConditionNode
    {
        public float range = 1;

        #region Overrides of Node

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (runnerGmob.TryGetComponent<CharacterInfo>(out CharacterInfo CI))
            {
                if (CI.currentTask != CharacterInfo.Task.Idle && Vector3.Distance(CI.taskPosition, CI.transform.position) <= range)
                    return State.Success;
            }
            return State.Failure;
        }
        #endregion
    }
}

