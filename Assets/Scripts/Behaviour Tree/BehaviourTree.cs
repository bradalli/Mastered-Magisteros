using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BT
{
    public abstract class BehaviourTree : MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}

