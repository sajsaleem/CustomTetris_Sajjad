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
    private float _winCondition = default;

    public List<BaseLevelSettings> LevelSettingsList { get => _levelSettingsList; }
    public List<BaseLevelSettings> UsedLevelsList { get; private set; } = new List<BaseLevelSettings>();
    public bool ShouldGenerateUniqueLevel { get => _shouldGenerateUniqueLevels; }
    public bool ShouldGenerateRandomLevel { get => _shouldGenerateRandomLevels; }

    public virtual void SetNewLevelSetting()
    {

        if (_shouldGenerateRandomLevels)
        {
            activeLevelData = _levelSettingsList[Random.Range(0, _levelSettingsList.Count)].level;
        }

        else if (_shouldGenerateUniqueLevels)
        {
            activeLevelData = GetUniqueLevel();
        }
    }

    private LevelData GetUniqueLevel()
    {
        for (int i = 0; i < LevelSettingsList.Count; i++)
        {
            if (!LevelSettingsList[i].level.isUsed)
                return LevelSettingsList[i].level;
        }

        return new LevelData();
    }

    public virtual LevelData GetLevel()
    {
        activeLevelData.isUsed = true;
        return activeLevelData;
    }

    public int WinCondition()
    {
        return (int)_winCondition;
    }

    public int LossCondition()
    {
        return activeLevelData.lossCondition;
    }

    public void UpdateWinCondition(float value)
    {
        if (_winCondition <= 0)
            _winCondition = value;
    }

}
