using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextWriter))]
public class TextWriterEditor : Editor {
    
    public SerializedProperty longStringProp;

    void OnEnable() {
        longStringProp = serializedObject.FindProperty("text");
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        serializedObject.Update();
        longStringProp.stringValue = EditorGUILayout.TextArea(longStringProp.stringValue, GUILayout.Height(100));
        serializedObject.ApplyModifiedProperties();
    }
}
