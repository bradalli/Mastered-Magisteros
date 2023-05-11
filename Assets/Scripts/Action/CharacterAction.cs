using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.Actions
{
    public class CharacterAction
    {
        public enum ActionType { Empty, Animation, Event}

        public string name = "YetToBeNamed";
        [Tooltip("If duration is 0, the action will never end.")]
        public float duration = 1f; // If duration is 0, the action will never end.
        [Tooltip("If location is (0,0,0), it is assumed there is no specific location to perform the action.")]
        public Vector3 location = Vector3.zero; // If location is (0,0,0), it is assumed there is no specific location to perform the action.
        public ActionType type = ActionType.Empty;

        public void TriggerAction()
        {

        }
    }
}

