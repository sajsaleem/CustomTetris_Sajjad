using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPlayersSpawner : IPlayersSpawner
{
    public static NullPlayersSpawner _instance;

    public static NullPlayersSpawner Instance
    {
        get
        {
            if (_instance == null)
                return new NullPlayersSpawner();

            return _instance;
        }
    }

    public List<PlayerType> PlayerEnvironments { get; private set; } = default;
    public List<PlayerType> InstantiatedPlayers { get; private set; } = default;

    public void SpawnPlayers(GameModeType _gameModeType)
    {

    }
}
