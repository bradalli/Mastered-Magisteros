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
#if UNITY_EDITOR
        public Node CreateNode(System.Type type)
        {
            Node node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();

            Undo.RecordObject(this, "Behaviour Tree (CreateNode)");
            nodes.Add(node);

            if (!Application.isPlaying)
            {
                AssetDatabase.AddObjectToAsset(node, this);
            }

            Undo.RegisterCreatedObjectUndo(node, "Behaviour Tree (CreateNode)");
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(Node node)
        {
            if(node != rootNode)
            {
                Undo.RecordObject(this, "Behaviour Tree (CreateNode)");
                nodes.Remove(node);

                //AssetDatabase.RemoveObjectFromAsset(node);
                Undo.DestroyObjectImmediate(node);
                AssetDatabase.SaveAssets();
            }
        }

        public void AddChild(Node parent, Node child)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (AddChild)");
                decorator.child = child;
                EditorUtility.SetDirty(decorator);
            }
                
            RootNode root = parent as RootNode;
            if (root)
            {
                Undo.RecordObject(root, "Behaviour Tree (AddChild)");
                root.child = child;
                EditorUtility.SetDirty(root);
            }

            CompositeNode composite = parent as CompositeNode;
            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (AddChild)");
                composite.children.Add(child);
                EditorUtility.SetDirty(composite);
            }
        }

        public void RemoveChild(Node parent, Node child)
        {
            DecoratorNode decorator = parent as DecoratorNode;
            if (decorator)
            {
                Undo.RecordObject(decorator, "Behaviour Tree (RemoveChild)");
                decorator.child = null;
                EditorUtility.SetDirty(decorator);
            }

            RootNode root = parent as RootNode;
            if (root)
            {
                Undo.RecordObject(root, "Behaviour Tree (RemoveChild)");
                root.child = null;
                EditorUtility.SetDirty(root);
            }

            CompositeNode composite = parent as CompositeNode;
            if (composite)
            {
                Undo.RecordObject(composite, "Behaviour Tree (RemoveChild)");
                composite.children.Remove(child);
                EditorUtility.SetDirty(composite);
            }
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

        public void Traverse(Mastered.Magisteros.BTwGraph.Node node, System.Action<Mastered.Magisteros.BTwGraph.Node> visitor)
        {
            if (node)
            {
                visitor.Invoke(node);
                var children = GetChildren(node);
                children.ForEach((n) => Traverse(n, visitor));
            }
        }

        public BehaviourTree Clone()
        {
            BehaviourTree tree = Instantiate(this);
            tree.rootNode = tree.rootNode.Clone();

            Traverse(tree.rootNode, (n) =>
            {
                tree.nodes.Add(n);
            });
            return tree;
        }
#endif
    }
}

