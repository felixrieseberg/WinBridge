using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(WBMessageDialog))]

public class WBMessageBoxEditor : Editor
{

    private bool foldCommand1;
    private bool foldCommand2;
    private bool usageFold;

    public override void OnInspectorGUI()
    {
        WBMessageDialog messageBoxTarget = (WBMessageDialog)target;

        EditorGUILayout.Space();
        messageBoxTarget.title = EditorGUILayout.TextField("Title", "");
        messageBoxTarget.label = EditorGUILayout.TextField("Message", "");
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("Using Commands is optional, but allows you to specify callback methods and labels for the buttons. You can specify none, only the 1st or both commands.", MessageType.Info);
        
        foldCommand1 = EditorGUILayout.Foldout(foldCommand1, "1st Command");
        if (foldCommand1)
        {
            messageBoxTarget.firstCommandLabel = EditorGUILayout.TextField("Label", "");
            messageBoxTarget.firstCommandReceivingObject = (GameObject)EditorGUILayout.ObjectField("Reciever", messageBoxTarget.firstCommandReceivingObject, typeof(GameObject), true);
            messageBoxTarget.firstCommandMethod = EditorGUILayout.TextField("Method to call", "");
        }
        foldCommand2 = EditorGUILayout.Foldout(foldCommand2, "2nd Command");
        if (foldCommand2)
        {
            messageBoxTarget.secondCommandLabel = EditorGUILayout.TextField("Label", "");
            messageBoxTarget.secondCommandRecievingObject = (GameObject)EditorGUILayout.ObjectField("Reciever", messageBoxTarget.secondCommandRecievingObject, typeof(GameObject), true);
            messageBoxTarget.secondCommandMethod = EditorGUILayout.TextField("Method to call", "");
        }

        usageFold = EditorGUILayout.Foldout(usageFold, "Usage Info");
        if (usageFold)
        {
            EditorGUILayout.HelpBox("To display this message dialog, call the method 'Show' on this component.", MessageType.Info);
        }

    }

}
