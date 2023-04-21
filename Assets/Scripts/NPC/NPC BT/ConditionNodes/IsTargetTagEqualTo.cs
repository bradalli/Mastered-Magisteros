using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class IsTargetTagEqualTo : ConditionNode
    {
        public string tagToCompare;

        #region Overrides of Node

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            if (runnerGmob.TryGetComponent<CharacterInfo>(out CharacterInfo CI))
            {
                if (CI.viewTarget != null && CI.viewTarget.CompareTag(tagToCompare))
                    return State.Success;
            }
            return State.Failure;
        }
        #endregion
    }
}

