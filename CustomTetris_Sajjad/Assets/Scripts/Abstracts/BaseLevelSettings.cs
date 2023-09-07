using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class BaseLevelSettings : ScriptableObject
{
    public LevelData level;
}

#if UNITY_EDITOR
[CustomEditor(typeof(LevelSettings))]
public class BaseLevelSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelSettings scriptableObject = (LevelSettings)target;

        // Display a custom help box with instructions.
        EditorGUILayout.HelpBox("Instructions: Enter level data or configure settings here.", MessageType.Info);
        EditorGUILayout.HelpBox("Instructions: horizontal area: 0 = Extreme left of Camera, 1 = Extreme Right.", MessageType.Info);
        EditorGUILayout.HelpBox("Instructions: spawn height: 0 = bottom of Camera, 1 = top of camera.", MessageType.Info);

        // Draw the default inspector for the ScriptableObject.
        DrawDefaultInspector();

        // Add additional custom GUI elements or instructions as needed.

    }
}
#endif
