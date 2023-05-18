using Mastered.Magisteros.BTwGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.Actions;

namespace Mastered.Magisteros.NPC
{
    public class Character : MonoBehaviour
    {
        #region Public variables

        [Header("Character Profile")]
        public CharacterProfile profile;
        public Personality personality = Personality.Friendly;
        public string characterName = "NotYetAssigned";
        public UnityEngine.Object meshPrefab = null;

        public enum Personality { Friendly, Hostile, Fearful }

        [Header("Base Stats")]
        public int baseHealth;
        public int baseSpeed;

        [Header("Current Stats")]
        public int currHealth;
        public int currSpeed;

        [Header("Status Information")]
        public bool isDead;
        public bool isAnActionBeingPerformed;
        public bool isInCombat;
        public bool areWaypointsRemaining;

        [Header("Action Information")]
        public string currentActionName;
        public Vector3 actionPosition;
        public CharacterAction currentAction;

        [Header("Miscellaneous")]
        public Transform viewTarget;

        #endregion

        #region Private variables

        Transform meshParentTransform;

        #endregion

        #region Monobehaviour methods

        private void Awake()
        {
            meshParentTransform = transform.Find("Mesh");
        }

        private void Update()
        {
            #region For Testing Purposes
            if (Input.GetKeyDown(KeyCode.Alpha1))
                isDead = !isDead;

            if (Input.GetKeyDown(KeyCode.Alpha2))
                isAnActionBeingPerformed = !isAnActionBeingPerformed;

            if (Input.GetKeyDown(KeyCode.Alpha3))
                isInCombat = !isInCombat;

            if (Input.GetKeyDown(KeyCode.Alpha4))
                areWaypointsRemaining = !areWaypointsRemaining;
            #endregion
        }

        [ExecuteInEditMode]
        private void OnValidate()
        {
            meshParentTransform = transform.Find("Mesh");

            transform.name = $"NPC - {characterName}";

            /*
            if (meshParentTransform.childCount > 0)
            {
                foreach(Transform child in meshParentTransform)
                    GameObject.DestroyImmediate(child);
            }
              
            if(meshPrefab != null)
            {
                Transform mesh = Instantiate(meshPrefab, meshParentTransform) as Transform;
                mesh.rotation = meshParentTransform.rotation;
            }*/
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position + Vector3.up, new Vector3(1, 2, 1));
        }

        #endregion

        #region Public methods

        public bool AreWaypointsRemaining()
        {
            return areWaypointsRemaining;
        }

        public bool InCombat()
        {
            return isInCombat;
        }

        public bool IsATaskBeingPerformed()
        {
            return isAnActionBeingPerformed;
        }

        public bool IsDead()
        {
            return isDead;
        }

        #endregion
    }
}

