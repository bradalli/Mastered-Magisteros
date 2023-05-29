using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.Actions
{
    [CreateAssetMenu(fileName = "Character Action", menuName = "Character Action", order = 1)]
    public class CharacterAction: ScriptableObject
    {
        public enum ActionType { Empty, Animation, Event, Talk}

        public string name = "YetToBeNamed";
        [Tooltip("If duration is 0, the action will never end.")]
        public float duration = 1f; // If duration is 0, the action will never end.
        [Tooltip("If location is (0,0,0), it is assumed there is no specific location to perform the action.")]
        public Vector3 location = Vector3.zero; // If location is (0,0,0), it is assumed there is no specific location to perform the action.
        public ActionType type = ActionType.Empty;
        public AnimationClip animClip;
        public float range = 5;

        public void TriggerAction()
        {
            Debug.Log("No event attached");
        }

        public void TriggerAnimation()
        {
            Debug.Log("No animation attached");
        }
    }
}

