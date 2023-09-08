using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class BlocksDataModifier : ScriptableWizard
{
    [Dropdown("fileNamesList")]
    public string ScriptableAsset;

    #region Exposed Variables
    [Tooltip("Update fall speed multiplier to gravity value")]
    [SerializeField] private float normalFallSpeed = default;

    [Tooltip("Updates rotation speed for each falling block")]
    [SerializeField] private float rotationSpeed = default;

    [Tooltip("Updates rotation to target value when screen is tapped")]
    [SerializeField] private float targetRotation = default;

    [Tooltip("Updates gravity value for each block")]
    [SerializeField] private Vector3 gravity = Physics.gravity;

    [Tooltip("Updates localScale for each block")]
    [SerializeField] private Vector3 localScale = Vector3.one;

    [Tooltip("Defines allowed movement area for each block horizontally")]
    [SerializeField] private Vector2 horizontalMovementArea = default;
    #endregion

    #region private Variables
    private string directoryPath = "Assets/ScriptableObjects/BlocksData/";
    private string selectedFileName;
    private List<string> fileNamesList = default;
    private BlocksDataModifier instance;
    private BaseBlockSettings _blockSettings = null;

    private float originalnormalFallSpeed = default;
    private float originalrotationSpeed = default;
    private float originaltargetRotation = default;
    private Vector3 originalgravity = default;
    private Vector3 originallocalScale = default;
    private Vector2 originalhorizontalMovementArea = default;
    #endregion

    [MenuItem("Tools/Blocks Data Editor")]
    static void CreateWizard()
    {
        BlocksDataModifier wizard = DisplayWizard<BlocksDataModifier>("Blocks Data Modifier", "Close" , "Update");
        wizard.instance = wizard;
    }

    private void OnWizardCreate()
    {

    }

    private void OnEnable()
    {
        RefreshFileNames();
        ScriptableAsset = fileNamesList[0];
        LoadScriptableObject();
    }

    private void OnWizardUpdate()
    {

        if (_blockSettings == null)
            return;

        if (ScriptableAsset != _blockSettings.name +".asset")
        {
            LoadScriptableObject();
            return;
        }

        if (instance != null && AnyValueUpdated())
        {
            EditorUtility.SetDirty(instance);
        }

        helpString = "Select BlockDataSetting from dropdown, update values, press update to update the scriptable object or Close to clost the Wizard";
    }

    private bool AnyValueUpdated()
    {
        if (normalFallSpeed != originalnormalFallSpeed)
            return true;
        if (rotationSpeed != originalrotationSpeed)
            return true;
        if (targetRotation != originaltargetRotation)
            return true;
        if (gravity != originalgravity)
            return true;
        if (localScale != originallocalScale)
            return true;
        if (horizontalMovementArea != originalhorizontalMovementArea)
            return true;

        return false;
    }

    // This method updates the list of file names based on the selected directory path.
    private void RefreshFileNames()
    {
        if (Directory.Exists(directoryPath))
        {
            fileNamesList = Directory.GetFiles(directoryPath)
                                .Select(Path.GetFileName).Where(s => Path.GetExtension(s) == ".asset")
                                .ToList();
        }
        else
        {
            Debug.Log("No assets found");
            /* fileNames = new string[0];*/ // No files found if the directory doesn't exist.
        }
    }

    void LoadScriptableObject()
    {
        AssetDatabase.Refresh();
        string path = Path.Combine(directoryPath + ScriptableAsset);
        _blockSettings = AssetDatabase.LoadAssetAtPath<BaseBlockSettings>(path);
        InitializeVariables();

    }

    private void InitializeVariables()
    {
        if (_blockSettings != null)
        {
            originalnormalFallSpeed = _blockSettings.blockData.normalFallSpeed;
            originaltargetRotation = _blockSettings.blockData.targetRotation;
            originalrotationSpeed = _blockSettings.blockData.rotationSpeed;
            originallocalScale = _blockSettings.blockData.localScale;
            originalgravity = _blockSettings.blockData.gravity;
            originalhorizontalMovementArea = _blockSettings.blockData.horizontalMovementArea;

            normalFallSpeed = originalnormalFallSpeed;
            targetRotation = originaltargetRotation;
            rotationSpeed = originalrotationSpeed;
            localScale = originallocalScale;
            gravity = originalgravity;
            horizontalMovementArea = originalhorizontalMovementArea;
        }
    }

    private void UpdateLevelValues()
    {
        _blockSettings.blockData.normalFallSpeed = normalFallSpeed;
        _blockSettings.blockData.rotationSpeed = rotationSpeed;
        _blockSettings.blockData.targetRotation = targetRotation;
        _blockSettings.blockData.localScale = localScale;
        _blockSettings.blockData.gravity = gravity;
        _blockSettings.blockData.horizontalMovementArea = horizontalMovementArea;
    }

    // Create a dropdown in the wizard for selecting the file.
    void OnWizardOtherButton()
    {
        if (_blockSettings != null)
        {
            UpdateLevelValues();
            EditorUtility.SetDirty(_blockSettings);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
