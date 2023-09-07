using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    GameStates GameState { get; }
    GameModeType ActiveGameMode { get; }
    void StartLevelSequence(GameModeType _gameModeType);
    void StartGameplay();
    void EndPlay();
    void ResetAll();
    void UpdateGameState(GameStates _gamestate);
}
