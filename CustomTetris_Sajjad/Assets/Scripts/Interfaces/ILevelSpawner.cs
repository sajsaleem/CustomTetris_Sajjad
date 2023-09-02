using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSpawner
{
    List<BaseLevelSettings> LevelScriptableObjects { get; }

    void InstantiateLevelPrefab(LevelType levelType);
}
