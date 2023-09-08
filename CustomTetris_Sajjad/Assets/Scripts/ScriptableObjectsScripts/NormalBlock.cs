using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NormalPieceData" , menuName = ConstantsManager.MenuName.ScriptableObjects +"/NormalPieceData")]
public class NormalBlockData : BaseBlockSettings
{
    public override float CalculateNormalFallSpeed()
    {
        return blockData.normalFallSpeed * blockData.gravity.y;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NormalBlockData))]
public class BaseBlockSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NormalBlockData scriptableObject = (NormalBlockData)target;

        // Display a custom help box with instructions.
        EditorGUILayout.HelpBox("Instructions: Enter Block data or configure settings here.", MessageType.Info);
        EditorGUILayout.HelpBox("Instructions: Fall speed is multiplier to gravity.", MessageType.Info);
        EditorGUILayout.HelpBox("Instructions: Horizontal Movement Area: 0 = left of Camera, 1 = right of camera.", MessageType.Info);
        EditorGUILayout.HelpBox("Instructions: You can easily change gravity value without actually changing Engine's gravity. So do it as you please :)", MessageType.Info);

        // Draw the default inspector for the ScriptableObject.
        DrawDefaultInspector();
    }
}
#endif
