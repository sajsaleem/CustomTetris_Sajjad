using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSpawner : MonoBehaviour ,IPlayersSpawner
{
    [SerializeField] private List<PlayerType> players;

    public List<PlayerType> PlayerEnvironments { get => players; }
    public List<PlayerType> InstantiatedPlayers { get; private set; } = new List<PlayerType>();

    public void SpawnPlayers(GameModeType _gameModeType)
    {
        switch(_gameModeType)
        {
            case GameModeType.SinglePlayer:
                InstantiatePlayer(PlayerTags.Player0);
                break;
            case GameModeType.TwoPlayer:
                InstantiatePlayer(PlayerTags.Player0);
                InstantiatePlayer(PlayerTags.Player1);
                break;
        }
    }

    private void InstantiatePlayer(PlayerTags playerTag)
    {
        for (int i = 0; i < InstantiatedPlayers.Count; i++)
        {
            if (InstantiatedPlayers[i].PlayerTag == playerTag)
            {
                InstantiatedPlayers[i].gameObject.SetActive(true);
                return;
            }
        }

        PlayerType newObject = default;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].PlayerTag == playerTag)
            {
                Debug.Log("Instantiate New Player");
                newObject = Instantiate(players[i]);
                InstantiatedPlayers.Add(newObject);
                break;
            }
        }
    }
}
