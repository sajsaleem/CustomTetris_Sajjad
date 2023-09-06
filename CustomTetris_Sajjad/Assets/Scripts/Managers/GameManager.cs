using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class GameManager : MonoBehaviour, IGameManager
{    
    public GameStates GameState { get; private set; } = default;
    public GameModeType ActiveGameMode { get; private set; } = default;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Managers.MenuController.ActivateUi(MenuType.StartMenu);
        Managers.BlockObjectsPooler.Initialize();
        Managers.CameraMaster.Initialize();
        ResetDebugPanel();
    }

    public void StartPlay(GameModeType _gameModeType)
    {
        ActiveGameMode = _gameModeType;
        Managers.LevelMaster.SetNewLevelSetting();
        Managers.CameraMaster.SetCamerasActiveStatus(ActiveGameMode);
        Managers.PlayersSpawner.SpawnPlayers(_gameModeType);
        Managers.MenuController.ActivateUi(MenuType.GameMenu);

    }

    public void EndPlay()
    {
        GameState = GameStates.GameOverState;
        Managers.MenuController.ActivateUi(MenuType.GameOver);
        Managers.MenuController.DisableUi(MenuType.GameMenu);
    }

    public void ResetAll()
    {
        // Disable all pooled items;
        Managers.BlockObjectsPooler.ReturnAllBlocksToPool();

        // Disable All players spawned;
        Managers.PlayersSpawner.Reset();

        Managers.ResultManager.Reset();

    }

    public void UpdateGameState(GameStates _gamestate)
    {
        GameState = _gamestate;
    }


    private async void SetGamePlayState()
    {
        await Task.Delay(1000);
        //GameState = GameStates.PlayState;
    }

    private void ResetDebugPanel()
    {
        if(DebugPanelManager.Instance)
        {
            DebugPanelManager.Instance.Reset(); 
        }
    }
}
