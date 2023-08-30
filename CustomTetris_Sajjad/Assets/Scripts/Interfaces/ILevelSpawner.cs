using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSpawner
{
    List<BaseLevelSettings> LevelScriptableObjects { get; }

    void InstantiateLevelPrefab(LevelType levelType);
    //List<GameObject> LevelPrefabs { get; }

    //void InstantiateLevelPrefab();

    //LevelSettings LevelSettings { get; }
    //GameObject SurfacePrefab { get; }
    //LevelType LevelType { get; }

    //void Generate_SP_Envrionment();
    //void Generate_TP_Environment();
}
