using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.Actions
{
    public class Action
    {
        public enum ActionType { Empty, Animation, Event}

        public Vector3 location = Vector3.zero;
        public ActionType type = ActionType.Empty;

        public void TriggerAction()
        {

        }
    }
}

