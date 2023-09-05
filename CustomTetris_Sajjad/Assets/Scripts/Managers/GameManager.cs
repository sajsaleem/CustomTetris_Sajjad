using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField] private BaseLevelMaster levelMaster;
    
    public GameStates GameState { get; private set; } = default;
    public GameModeType ActiveGameMode { get; private set; } = default;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Managers.MenuController.ActivateUi(MenuType.StartMenu);
        Managers.PiecesObjectPooler.Initialize();
    }

    public void StartPlay(GameModeType _gameModeType)
    {
        GameState = GameStates.PlayState;
        ActiveGameMode = _gameModeType;
        Managers.LevelMaster.SetNewLevelSetting();
        Managers.PlayersSpawner.SpawnPlayers(_gameModeType);
        Managers.MenuController.ActivateUi(MenuType.GameMenu);
    }

    public void EndPlay()
    {
        Debug.Log("Result Is result screen");
        Managers.MenuController.ActivateUi(MenuType.GameOver);
        Managers.MenuController.DisableUi(MenuType.GameMenu);
    }

    public void ResetAll()
    {
        // Disable all pooled items;
        Managers.PiecesObjectPooler.ReturnAllBlocksToPool();

        // Disable All players spawned;
        Managers.PlayersSpawner.Reset();

        Managers.ResultManager.Reset();

    }
}
