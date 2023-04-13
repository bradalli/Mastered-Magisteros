using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    [CreateAssetMenu(fileName = "BehaviourTree", menuName = "Behaviour Tree")]
    public class BehaviourTree : ScriptableObject
    {
        public Node rootNode;
        public Node.State treeState = Node.State.Running;

        public Node.State Update()
        {
            bool hasRootNode = rootNode != null;

            if (hasRootNode)
            {
                if (treeState == Node.State.Running)
                    treeState = rootNode.Update();
            }

            else
            {
                treeState = Node.State.Failure;
                Debug.LogWarning($"{name} needs a root node in order to properly run. Please add one.", this);
            }

            return treeState;
        }
    }
}

