using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mastered.Magisteros.BTwGraph
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree tree;
        void Start()
        {
            #region Hard-Coded BT Example
            /*
            tree = ScriptableObject.CreateInstance<BehaviourTree>();

            DebugLogNode log1 = ScriptableObject.CreateInstance<DebugLogNode>();
            log1.message = "Testing 1.";
            DebugLogNode log2 = ScriptableObject.CreateInstance<DebugLogNode>();
            log2.message = "Testing 2.";
            DebugLogNode log3 = ScriptableObject.CreateInstance<DebugLogNode>();
            log3.message = "Testing 3.";

            ActionNode wait1 =
                ScriptableObject.CreateInstance<WaitNode>();
            ActionNode wait2 =
                ScriptableObject.CreateInstance<WaitNode>();
            ActionNode wait3 =
                ScriptableObject.CreateInstance<WaitNode>();

            CompositeNode sequence =
                ScriptableObject.CreateInstance<SequencerNode>();
            sequence.children.Add(log1);
            sequence.children.Add(wait1);
            sequence.children.Add(log2);
            sequence.children.Add(wait2);
            sequence.children.Add(log3);
            sequence.children.Add(wait3);

            DecoratorNode loop = ScriptableObject.CreateInstance<RepeatNode>();
            loop.child = sequence;

            tree.rootNode = loop;
            */
            #endregion

            tree = tree.Clone();
        }

        void Update()
        {
            tree.Update();
        }
    }
}


