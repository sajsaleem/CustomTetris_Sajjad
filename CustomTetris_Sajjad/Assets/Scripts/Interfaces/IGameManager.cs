using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    GameStates GameState { get; }
    GameModeType ActiveGameMode { get; }
    void StartPlay(GameModeType _gameModeType);
    void EndPlay();
}
