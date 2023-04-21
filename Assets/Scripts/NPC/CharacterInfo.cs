using Mastered.Magisteros.BTwGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] bool isDead;
    [SerializeField] bool isATaskBeingPerformed;
    [SerializeField] bool isInCombat;
    [SerializeField] bool areWaypointsRemaining;
    public Task currentTask;
    public Vector3 taskPosition;
    internal GameObject viewTarget;

    public enum Task { Idle, Talk, Animation}

    private void Update()
    {
        #region For Testing Purposes
        if (Input.GetKeyDown(KeyCode.Alpha1))
            isDead = !isDead;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            isATaskBeingPerformed = !isATaskBeingPerformed;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            isInCombat = !isInCombat;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            areWaypointsRemaining = !areWaypointsRemaining;
        #endregion
    }

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
        return isATaskBeingPerformed;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
