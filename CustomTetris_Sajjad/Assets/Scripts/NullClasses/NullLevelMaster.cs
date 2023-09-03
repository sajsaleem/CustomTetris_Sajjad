using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullLevelMaster : ILevelMaster
{
    public static NullLevelMaster _instance;

    public static NullLevelMaster Instance
    {
        get
        {
            if (_instance == null)
                return new NullLevelMaster();

            return _instance;
        }
    }

    public List<BaseLevelSettings> LevelSettingsList { get; private set; } = default;
    public List<BaseLevelSettings> UsedLevelsList { get; private set; } = default;
    public bool ShouldGenerateUniqueLevel { get; private set; } = default;
    public bool ShouldGenerateRandomLevel { get; private set; } = default;

    public LevelData GetLevel()
    {
        return new LevelData();
    }

    public void SetNewLevelSetting()
    {

    }

    public int WinCondition()
    {
        return 0;
    }

    public int LossCondition()
    {
        return 0;
    }
}
