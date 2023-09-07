using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class LevelsDataModifier : ScriptableWizard
{
    [Dropdown("fileNamesList")]
    public string ScriptableAsset;

    #region Exposed Variables
    [Tooltip("Updates the Scaling of surface in three-dimensions")]
    [SerializeField] private Vector3 surfaceDimensions = default;

    [Tooltip("Updates the surface position from 0 position")]
    [SerializeField] private Vector3 surfacePosition = default;

    [Tooltip("Defines the range in X-Axis for spawning new blocks")]
    [SerializeField] private Vector2 horizontalSpawnArea; // 0 left , 1 right in X-Axis in normalized Viewport;

    [Tooltip("Height from where blocks should spawn within Camera Height")]
    [SerializeField] private float spawnHeight = default; // 1 top of the screen in normalized Viewport;

    [Tooltip("Height of tower required for winning")]
    [SerializeField] private int winCondition = default;

    [Tooltip("Amount of blocks lost that can make player loss a game")]
    [SerializeField] private int lossCondition = default;
    #endregion

    #region private Variables
    private string directoryPath = "Assets/ScriptableObjects/LevelSettings/";
    private List<string> fileNamesList = default;
    private LevelsDataModifier instance;
    private BaseLevelSettings levelSettings = null;

    private Vector3 originalSurfaceDimensions = default;
    private Vector3 originalSurfacePosition = default;
    private Vector2 originalHorizontalSpawnArea = default;
    private float originalSpawnHeight = default;
    private int originalWinCondition = default;
    private int originalLossCondition = default;
    #endregion

    [MenuItem("Tools/Levels Data Editor")]
    static void CreateWizard()
    {
        LevelsDataModifier wizard = DisplayWizard<LevelsDataModifier>("Level Data Modifier", "Close" , "Update");
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

        if (levelSettings == null)
            return;

        if (ScriptableAsset != levelSettings.name +".asset")
        {
            LoadScriptableObject();
            return;
        }

        if (instance != null && AnyValueUpdated())
        {
            EditorUtility.SetDirty(instance);
        }

        helpString = "Select LevelSetting from dropdown, update values, press update to update the scriptable object or Close to clost the Wizard";
    }

    private bool AnyValueUpdated()
    {
        if (surfaceDimensions != originalSurfaceDimensions)
            return true;
        if (surfacePosition != originalSurfacePosition)
            return true;
        if (winCondition != originalWinCondition)
            return true;
        if (lossCondition != originalLossCondition)
            return true;
        if (spawnHeight != originalSpawnHeight)
            return true;
        if (horizontalSpawnArea != originalHorizontalSpawnArea)
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
            Debug.Log("<color=red> No assets found </color>");
        }
    }

    void LoadScriptableObject()
    {
        AssetDatabase.Refresh();
        string path = Path.Combine(directoryPath + ScriptableAsset);
        levelSettings = AssetDatabase.LoadAssetAtPath<BaseLevelSettings>(path);
        InitializeVariables();

    }

    private void InitializeVariables()
    {
        if (levelSettings != null)
        {
            originalSurfaceDimensions = levelSettings.level.surfaceDimensions;
            originalSurfacePosition = levelSettings.level.surfacePosition;
            originalWinCondition = levelSettings.level.winCondition;
            originalLossCondition = levelSettings.level.lossCondition;
            originalSpawnHeight = levelSettings.level.spawnHeight;
            originalHorizontalSpawnArea = levelSettings.level.horizontalSpawnArea;

            surfaceDimensions = originalSurfaceDimensions;
            surfacePosition = originalSurfacePosition;
            winCondition = originalWinCondition;
            lossCondition = originalLossCondition;
            spawnHeight = originalSpawnHeight;
            horizontalSpawnArea = originalHorizontalSpawnArea;
        }
    }

    private void UpdateLevelValues()
    {
        levelSettings.level.surfaceDimensions = surfaceDimensions;
        levelSettings.level.surfacePosition = surfacePosition;
        levelSettings.level.winCondition = winCondition;
        levelSettings.level.lossCondition = lossCondition;
        levelSettings.level.spawnHeight = spawnHeight;
        levelSettings.level.horizontalSpawnArea = horizontalSpawnArea;
    }

    private void OnWizardOtherButton()
    {
        if (levelSettings != null)
        {
            UpdateLevelValues();
            EditorUtility.SetDirty(levelSettings);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
