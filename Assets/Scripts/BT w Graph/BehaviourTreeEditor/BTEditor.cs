using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class BTEditor : EditorWindow
{
    [MenuItem("Window/UI Toolkit/BTEditor")]
    public static void ShowExample()
    {
        BTEditor wnd = GetWindow<BTEditor>();
        wnd.titleContent = new GUIContent("BTEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/BT w Graph/BehaviourTreeEditor/BTEditor.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        
    }
}