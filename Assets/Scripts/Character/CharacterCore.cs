using Mastered.Magisteros.BTwGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.Actions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mastered.Magisteros.NPC
{
    public class CharacterCore : MonoBehaviour
    {
        #region Public variables

        [Header("Base Stats")]
        public int baseHealth;
        public int baseSpeed;

        [Header("Current Stats")]
        public int currHealth;
        public int currSpeed;
        private float movementSpeed;

        [Header("Action Information")]
        public string currentActionName;
        public Vector3 actionPosition;
        public CharacterAction currentAction;

        [Header("Miscellaneous")]
        public Transform viewTarget;

        [Header("UnityEvents")]
        public List<UnityEvent> unityActionList;

        #endregion

        Transform meshParentTransform;

        public void SetMoveSpeed(float newSpeed)
        {
            movementSpeed = newSpeed;
        }
    }
}

