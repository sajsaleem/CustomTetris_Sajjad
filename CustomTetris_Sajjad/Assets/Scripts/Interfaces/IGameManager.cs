using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    GameStates GameState { get; }
    void StartPlay(LevelType levelType);
    void EndPlay();
}
