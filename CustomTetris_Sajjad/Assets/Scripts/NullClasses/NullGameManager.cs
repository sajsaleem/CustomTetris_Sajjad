using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullGameManager : IGameManager
{
    public static NullGameManager _instance;

    public static NullGameManager Instance
    {
        get
        {
            if (_instance == null)
                return new NullGameManager();

            return _instance;
        }
    }

    public GameStates GameState { get; private set; } = default;
    public GameModeType ActiveGameMode { get; private set; } = default;


    public void StartPlay(GameModeType _gameModeType)
    {

    }

    public void EndPlay()
    {

    }

    public void ResetAll()
    {

    }
}
