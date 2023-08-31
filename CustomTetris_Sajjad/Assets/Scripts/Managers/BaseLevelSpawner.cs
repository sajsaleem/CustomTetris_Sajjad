using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract  class BaseLevelSpawner : MonoBehaviour, ILevelSpawner
{
    [SerializeField] private List<BaseLevelSettings> levelScriptableObjects = new List<BaseLevelSettings>();

    private List<BaseLevelMaster> instantiatedLevels = new List<BaseLevelMaster>();

    public List<BaseLevelSettings> LevelScriptableObjects => levelScriptableObjects;

    public virtual void InstantiateLevelPrefab(LevelType _levelType) 
    {

        BaseLevelSettings _levelSettings = levelScriptableObjects.First(t => t.level.levelPrefab.LevelType == _levelType);

        if(!IsAlreadyInstantiated(_levelSettings.level.levelPrefab))
        {
            BaseLevelMaster _level = Instantiate(_levelSettings.level.levelPrefab);
            _level.LevelSettings = _levelSettings;
            _levelSettings.level.isInstantiated = true;
            instantiatedLevels.Add(_level);
        }
        else
        {
            ActivateLevel(_levelType);
        }
    }

    public bool IsAlreadyInstantiated(BaseLevelMaster _level)
    {
        if (instantiatedLevels.Contains(_level))
            return true;
        //for(int i =0; i < instantiatedLevels.Count; i++)
        //{
        //    if (levelScriptableObjects[i].//level.isInstantiated)
        //        return true;
        //}

        return false;
    }

    private void ActivateLevel(LevelType _levelType)
    {
        instantiatedLevels.ForEach(
            obj =>
            {
                if (obj.LevelType == _levelType)
                    obj.gameObject.SetActive(true);
            });
    }

    //[SerializeField] private LevelSettings _levelSettings;
    //[SerializeField] private GameObject surfacePrefab;
    //[SerializeField] private GameObject finishLinePrefab;
    //[SerializeField] private LevelType _levelType;

    //private GameObject parent;

    //private float winCondition = default;
    //private float lossCondition = default;
    //private Vector3 surfaceDimensions = default;
    //private Vector3 surfacePosition = default;


    //public LevelSettings LevelSettings => _levelSettings;
    //public GameObject SurfacePrefab => surfacePrefab;
    //public LevelType LevelType => _levelType;

    //private void Start()
    //{
    //    GenerateLevel();
    //}

    //private void InitializeParams(LevelData levelData)
    //{
    //    winCondition = levelData.winCondition;
    //    lossCondition = levelData.lossCondition;
    //    surfaceDimensions = levelData.surfaceDimensions;
    //    //surfacePosition = levelData.surfacePosition;
    //}

    //private void GenerateLevel()
    //{
    //    //switch (_levelType)
    //    //{
    //    //    case LevelType.SinglePlayer:
    //    //        InitializeParams(_levelSettings.singlePlayerLevelData);
    //    //        Generate_SP_Envrionment();
    //    //        break;
    //    //    case LevelType.TwoPlayer:
    //    //        InitializeParams(_levelSettings.twoPlayerLevelData);
    //    //        Generate_TP_Environment();
    //    //        break;
    //    //}

    //    //switch (_levelSettings.levelType)
    //    //{
    //    //    case LevelType.SinglePlayer:
    //    //        InitializeParams(_levelSettings.singlePlayerLevelData);
    //    //        Generate_SP_Envrionment();
    //    //        break;
    //    //    case LevelType.TwoPlayer:
    //    //        InitializeParams(_levelSettings.twoPlayerLevelData);
    //    //        Generate_TP_Environment();
    //    //        break;
    //    //}
    //}

    //// Generates environment for single player experience;
    //public virtual void Generate_SP_Envrionment()
    //{
    //    //parent = GoPropertiesUpdateStaticClass.CreateNewGameObject(LevelSettings.levelType.ToString());
    //    GoPropertiesUpdateStaticClass.UpdateObjectPosition(parent.transform, Vector3.zero);
    //    Transform newSurface = GoPropertiesUpdateStaticClass.InstantiateObject(surfacePrefab);//InstantiateNewSurface(LevelSettings.singlePlayerLevelData);
    //    GoPropertiesUpdateStaticClass.UpdateObjectPosition(newSurface, surfacePosition);
    //    GoPropertiesUpdateStaticClass.UdpateObjectScale(newSurface, surfaceDimensions);

    //    Transform finishLine = GoPropertiesUpdateStaticClass.InstantiateObject(finishLinePrefab);
    //    float finishLineVerticalDistance =  CalculationsStaticClass.GetVerticalDistance(winCondition, newSurface.position.y, newSurface.localScale);
    //    GoPropertiesUpdateStaticClass.UpdateYPosition(finishLine, finishLineVerticalDistance);
    //}

    ////Generates environment for 2 player experience;
    //public virtual void Generate_TP_Environment()
    //{

    //}
}
