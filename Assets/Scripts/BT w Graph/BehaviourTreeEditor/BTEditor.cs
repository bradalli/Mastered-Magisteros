using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Mastered.Magisteros.BTwGraph;
using UnityEditor.Callbacks;

public class BTEditor : EditorWindow
{
    [MenuItem("Window/Behaviour Tree/Editor")]
    public static void OpenTreeEditor()
    {
        GetWindow<BTEditor>("Behaviour Tree Editor");
    }

    public void CreateGUI()
    {
        VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
            "Assets/Scripts/BTwGraph/BehaviourTreeEditor/BTEditor.xml");
        visualTree.CloneTree(rootVisualElement);
    }

    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;
        if (tree != null) 
        {
            SerializedObject so = new SerializedObject(tree);
            rootVisualElement.Unbind();
        }
        else 
        {
            rootVisualElement.Unbind();

            TextField textField = rootVisualElement.Q<TextField>("BehaviourTreeName");
            if(textField != null)
            {
                textField.value = string.Empty;
            }
        }

    }
}
