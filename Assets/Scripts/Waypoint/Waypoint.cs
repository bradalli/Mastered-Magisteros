using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mastered.Magisteros.Actions;

namespace Mastered.Magisteros.Waypoints
{
    public class Waypoint : MonoBehaviour
    {
        public Waypoint nextWaypoint;
        public Vector3 location;

        public bool isLoop = false;
        public bool isWander = false;
        public bool hasAction = false;
        public CharacterAction action = new CharacterAction();
    }
}

