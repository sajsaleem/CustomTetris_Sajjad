using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayersSpawner
{
    List<PlayerType> PlayerEnvironments { get; }
    List<PlayerType> InstantiatedPlayers { get; }

    void SpawnPlayers(GameModeType _gameModeType);
    void Reset();
}
