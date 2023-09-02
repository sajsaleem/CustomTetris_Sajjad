using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerSpawner : MonoBehaviour, IPlayersSpawner
{
    [SerializeField] private List<PlayerType> _playerEnvironments = new List<PlayerType>();

    public List<PlayerType> InstantiatedEnvironments { get; private set; } = default;

    public List<PlayerType> PlayerEnvironments { get => _playerEnvironments; }

    public void SpawnPlayer(PlayerTags playerTag)
    {
        //if (!IsAlreadyInstantiated(playerTag))
        //{

        //}
    }

    //private bool IsAlreadyInstantiated(PlayerTags playerTag)
    //{
    //    if(InstantiatedEnvironments.Contains((typeof)playerTag))
    //    return false;
    //}
}
