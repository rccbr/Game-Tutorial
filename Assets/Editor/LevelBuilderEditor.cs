using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LevelBuilder))]
public class LevelBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelBuilder levelConstructor = (LevelBuilder)target;

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Build Level"))
        {
            levelConstructor.LevelCreator();
        }
    }
}
