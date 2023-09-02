using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayersSpawner
{
    List<PlayerType> PlayerEnvironments { get; }
    List<PlayerType> InstantiatedEnvironments { get; }

    void SpawnPlayer(PlayerTags playerTag);
}
