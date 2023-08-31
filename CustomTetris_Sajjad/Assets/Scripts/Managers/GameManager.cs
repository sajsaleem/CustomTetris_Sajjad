using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    public void StartPlay(LevelType levelType)
    {
        Managers.LevelSpawner.InstantiateLevelPrefab(levelType);
    }

    private void Update()
    {
        if(Managers.TowerManager.TowerHeight >= 10)
        {
            EndPlay();
        }
    }

    public void EndPlay()
    {
        Debug.Log("Result Is result screen");
    }
}
