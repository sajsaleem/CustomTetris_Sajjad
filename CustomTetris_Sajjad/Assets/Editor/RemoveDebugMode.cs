using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif
using System.Linq;

public class RemoveDebugMode : ScriptableObject
{

#if UNITY_EDITOR

    [MenuItem("Tools/Remove All Debug Modes", false, 40)]
    static void RemoveAllDebugModes()
    {
        string[] scenes = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();

        foreach (string sceneName in scenes)
        {
            Scene scene = EditorSceneManager.OpenScene(sceneName);

            MonoBehaviour[] monoscripts = FindObjectsOfType<MonoBehaviour>();

            foreach (MonoBehaviour mono in monoscripts)
            {
                FieldInfo[] objectFields = mono.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                EditorUtility.SetDirty(mono);
                EditorUtility.SetDirty(mono.gameObject);
                for (int j = 0; j < objectFields.Length; j++)
                {
                    DevDebugMode attribute = Attribute.GetCustomAttribute(objectFields[j], typeof(DevDebugMode)) as DevDebugMode;

                    if (attribute != null)
                    {
                        objectFields[j].SetValue(mono, false);
                        Debug.LogFormat("<color = cyan> Field: {0}, Value: {1}", objectFields[j].Name, objectFields[j].GetValue(mono));
                    }
                }
            }

            EditorSceneManager.SaveScene(scene);
        }

    }

#endif
}
