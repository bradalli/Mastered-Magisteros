using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public abstract class Node : ScriptableObject
    {
        public enum State
        {
            Running,
            Success,
            Failure
        }

        [HideInInspector] [SerializeField] private State state = State.Running;
        [HideInInspector] [SerializeField] private bool started;
        [HideInInspector] public string guid;
        [HideInInspector] public Vector2 position;

        ///<summary>
        /// Runs when the Node first starts running.
        /// Initialize the Node.
        /// </summary>
        protected abstract void OnStart();

        ///<summary>
        /// Runs when the Node stops.
        /// Any cleanup that the Node may need to do.
        /// </summary>
        protected abstract void OnStop();

        protected abstract State OnUpdate();

        public State Update()
        {
            // If the node has not started, start the Node.
            if(!started)
            {
                OnStart();
                started = true;
            }

            // set the state and run the nodes child update logic.
            state = OnUpdate();

            // If the state is not running the state is failure or success (in case I decide to add other states later.
            if (state != State.Failure && state != State.Success) return state;

            // stop the node.
            OnStop();
            started = false;
            return state;
        }

        public virtual Node Clone()
        {
            return Instantiate(this);
        }
    }
}

