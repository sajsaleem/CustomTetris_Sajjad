using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevelMaster : MonoBehaviour,ILevelMaster
{
    [SerializeField] private List<BaseLevelSettings> _levelSettingsList = new List<BaseLevelSettings>();
    [SerializeField] private bool _shouldGenerateUniqueLevels;
    [SerializeField] private bool _shouldGenerateRandomLevels;

    private LevelData activeLevelData;

    public List<BaseLevelSettings> LevelSettingsList { get => _levelSettingsList; }
    public List<BaseLevelSettings> UsedLevelsList { get; private set; } = new List<BaseLevelSettings>();
    public bool ShouldGenerateUniqueLevel { get => _shouldGenerateUniqueLevels; }
    public bool ShouldGenerateRandomLevel { get => _shouldGenerateRandomLevels; }

    public void SetNewLevelSetting()
    {
        if(_shouldGenerateRandomLevels)
        {
            activeLevelData = _levelSettingsList[Random.Range(0, _levelSettingsList.Count)].level;
        }

        else if(_shouldGenerateUniqueLevels)
        {
            activeLevelData = GetUniqueLevel();
        }
    }

    public LevelData GetUniqueLevel()
    {
        for (int i = 0; i < LevelSettingsList.Count; i++)
        {
            if (!LevelSettingsList[i].level.isUsed)
                return LevelSettingsList[i].level;
        }

        return new LevelData();
    }

    public LevelData GetLevel()
    {
        activeLevelData.isUsed = true;
        return activeLevelData;
    }


    //[SerializeField] private LevelType levelType;
    //[SerializeField] private List<Transform> surfaces = new List<Transform>();
    //[SerializeField] private Transform finishLine;
    //[SerializeField] private LevelSettings levelSettings;

    ////public LevelType LevelType { get; }
    //public List<Transform> Surfaces { get; }
    //public Transform FinishLine { get; }   
    //public BaseLevelSettings LevelSettings { get; }
    //public bool IsInstantiated { get; set; }

    //public virtual void Initialize()
    //{

    //    int surfacesIndex = 0;

    //    surfaces.ForEach(
    //        obj =>
    //        {
    //            obj.position = LevelSettings.level.surfacePosition[surfacesIndex];
    //            obj.localScale = LevelSettings.level.surfaceDimensions;
    //            surfacesIndex++;
    //        });


    //    float finishLineYPos = CalculationsStaticClass.GetVerticalDistance(LevelSettings.level.winCondition, GetMaxYPositionFromList(surfaces), GetObjectYScale(surfaces[0]));
    //    finishLine.position = new Vector3(finishLine.position.x, finishLineYPos, finishLine.position.z);
    //}

    //private float GetMaxYPositionFromList(List<Transform> transforms)
    //{
    //    float max = default;

    //    transforms.ForEach(
    //        obj =>
    //        {
    //            if (obj.position.y > max)
    //                max = obj.position.y;
    //        });

    //    return max;

    //}

    //private float GetObjectYScale(Transform _transform)
    //{
    //    return _transform.localScale.y;
    //}
}
