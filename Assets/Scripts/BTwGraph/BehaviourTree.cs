using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

namespace Mastered.Magisteros.BTwGraph
{
    [CreateAssetMenu(fileName = "BehaviourTree", menuName = "Behaviour Tree")]
    public class BehaviourTree : ScriptableObject
    {
        public Node rootNode;
        public Node.State treeState = Node.State.Running;
        public List<Node> nodes = new List<Node>();
        public GameObject runnerGmob;

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

        public Node CreateNode(System.Type type)
        {
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();
            nodes.Add(node);

            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            if(node != rootNode)
            {
                nodes.Remove(node);
                AssetDatabase.RemoveObjectFromAsset(node);
                AssetDatabase.SaveAssets();
            }
        }

        public void AddChild(Node parent, Node child)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator)
                decorator.child = child;

            RootNode rootNode = parent as RootNode;
            if (rootNode)
                rootNode.child = child;

            CompositeNode composite = parent as CompositeNode;
            if (composite)
                composite.children.Add(child);
        }

        public void RemoveChild(Node parent, Node child)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator)
                decorator.child = null;

            RootNode rootNode = parent as RootNode;
            if (rootNode)
                rootNode.child = null;

            CompositeNode composite = parent as CompositeNode;
            if (composite)
                composite.children.Remove(child);
        }

        public List<Node> GetChildren(Node parent)
        {
            List<Node> children = new List<Node>();

            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator && decorator.child != null)
                children.Add(decorator.child);

            RootNode rootNode = parent as RootNode;
            if (rootNode && rootNode.child != null)
                children.Add(rootNode.child);

            CompositeNode composite = parent as CompositeNode;
            if (composite)
                return composite.children;

            return children;
        }

        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();
            return tree;
        }
    }
}

