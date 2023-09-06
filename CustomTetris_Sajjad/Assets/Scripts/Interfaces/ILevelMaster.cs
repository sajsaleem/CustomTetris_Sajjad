using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelMaster
{
    //LevelType LevelType { get; }
    //List<Transform> Surfaces { get; }
    //Transform FinishLine { get; }
    //BaseLevelSettings LevelSettings { get; }
    //bool IsInstantiated { get; set; }



    List<BaseLevelSettings> LevelSettingsList { get; }
    List<BaseLevelSettings> UsedLevelsList { get; }
    bool ShouldGenerateUniqueLevel { get; }
    bool ShouldGenerateRandomLevel { get; }

    LevelData GetLevel();
    int WinCondition();
    int LossCondition();
    void SetNewLevelSetting();
    void UpdateWinCondition(float value);

}
