using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : BaseLevelSpawner
{
    // Start is called before the first frame update
    void Start()
    {
        //InstantiateLevelPrefab(LevelType.SinglePlayer);
    }

    public override void InstantiateLevelPrefab(GameModeType _gameModeType)
    {
        base.InstantiateLevelPrefab(_gameModeType);
    }
}
