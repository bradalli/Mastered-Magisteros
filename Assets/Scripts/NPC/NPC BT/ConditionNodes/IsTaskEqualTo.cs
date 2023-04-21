using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class IsTaskEqualTo : ConditionNode
    {
        public CharacterInfo.Task taskToCompare;

        #region Overrides of Node

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if(runnerGmob.TryGetComponent<CharacterInfo>(out CharacterInfo CI))
            {
                if (CI.currentTask == taskToCompare)
                    return State.Success;
            }
            return State.Failure;
        }
        #endregion
    }
}

