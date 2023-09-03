using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField] private BaseLevelMaster levelMaster;
    public GameStates GameState { get; private set; } = default;
    public GameModeType ActiveGameMode { get; private set; } = default;

    public void StartPlay(GameModeType _gameModeType)
    {
        Debug.Log("Start Player");
        GameState = GameStates.PlayState;
        ActiveGameMode = _gameModeType;
        //levelMaster.SetNewLevelSetting();
        Managers.LevelMaster.SetNewLevelSetting();
        Managers.PlayersSpawner.SpawnPlayers(_gameModeType);
    }

    public void EndPlay()
    {
        Debug.Log("Result Is result screen");
    }
}
