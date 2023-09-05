using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Linq;
using System;

public class LevelsDataModifier : ScriptableWizard
{
    private string directoryPath = Application.dataPath + "/ScriptableObjects/LevelSettings";
    private string selectedFileName;
    private List<string> fileNames = default;

    [Dropdown("FilesList")]
    public string fileName;

    [MenuItem("Tools/Levels Data Editor")]
    static void CreateWizard()
    {
        DisplayWizard<LevelsDataModifier>("File Dropdown Wizard", "Load");
        //DisplayWizard<LevelsDataModifier>("File Dropdown Wizard", "Update");
    }

    private void OnWizardCreate()
    {
        
    }

    private void OnEnable()
    {
        RefreshFileNames();
    }

    // This method updates the list of file names based on the selected directory path.
    private void RefreshFileNames()
    {
        if (Directory.Exists(directoryPath))
        {
            fileNames = Directory.GetFiles(directoryPath)
                                 .Select(Path.GetFileName)
                                 .ToList();
        }
        else
        {
           /* fileNames = new string[0];*/ // No files found if the directory doesn't exist.
        }
    }

    // Create a dropdown in the wizard for selecting the file.
    void OnWizardOtherButton()
    {
        //int selectedFileIndex = EditorGUILayout.Popup("Select a File", GetSelectedFileIndex(), fileNames);

        //if (selectedFileIndex >= 0 && selectedFileIndex < fileNames.Length)
        //{
        //    selectedFileName = fileNames[selectedFileIndex];
        //}
        //else
        //{
        //    selectedFileName = null;
        //}
    }

    // Helper method to get the index of the selected file in the fileNames array.
    private int GetSelectedFileIndex()
    {
        if (!string.IsNullOrEmpty(selectedFileName))
        {
            for (int i = 0; i < fileNames.Count; i++)
            {
                if (fileNames[i] == selectedFileName)
                {
                    return i;
                }
            }
        }
        return -1; // Selected file not found in the array.
    }
}
