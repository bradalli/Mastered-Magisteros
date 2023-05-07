using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.NPC;

namespace Mastered.Magisteros.BTwGraph
{
    public class IsTaskEqualTo : ConditionNode
    {
        public CharacterInformation.Task taskToCompare;

        #region Overrides of Node

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if(runnerGmob.TryGetComponent<CharacterInformation>(out CharacterInformation CI))
            {
                if (CI.currentTask == taskToCompare)
                    return State.Success;
            }
            return State.Failure;
        }
        #endregion
    }
}

