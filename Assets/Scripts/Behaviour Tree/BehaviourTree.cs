using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BT
{
    public abstract class BehaviourTree : MonoBehaviour
    {
        private Node _root = null;
        public bool reset = false;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null && !reset)
            {
                _root.Evaluate();
            } 

            else if (reset)
            {
                _root = SetupTree();
                reset = false;
            }
        }
        protected abstract Node SetupTree();
    }
}

