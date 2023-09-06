using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressTracker : MonoBehaviour,IPlayerProgressTracker
{
    public ITowerManager TowerManager { get; private set; } = default;
    public int PiecesLost { get; private set; } = default;


    private int winCondition = default;
    private int lossCondition = default;
    private IPlayerType playerType;

    private void Start()
    {
        TowerManager = GetComponent<ITowerManager>();
        playerType = GetComponent<IPlayerType>();
        winCondition = Managers.LevelMaster.WinCondition();
        lossCondition = Managers.LevelMaster.LossCondition();
    }

    private void OnDisable()
    {
        Reset();
    }

    public void RemoveBlock(Transform _transform)
    {
        // removes block from tower;
        TowerManager.RemoveBlock(_transform);
        UpdatePiecesLost();
        UpdateTowerHeightOnDebug();

        if (PiecesLost >= lossCondition)
        {
            // Do Loss Action here;
            Managers.ResultManager.UpdateLooser(playerType.PlayerTag.ToString());
            Managers.GameManager.EndPlay();
        }
    }

    public void AddBlock(Transform _transform)
    {
        //Adds block to tower;
        TowerManager.AddBlock(_transform);
        UpdateTowerHeightOnDebug();

        if (TowerManager.TowerHeight >= winCondition)
        {
            // Do Win Action;
            Managers.ResultManager.UpdateWinner(playerType.PlayerTag.ToString());
            Managers.GameManager.EndPlay();
            return;
        }

        Managers.CameraMaster.MoveUp(playerType.PlayerTag, TowerManager.TowerHeight);
    }

    private void UpdatePiecesLost()
    {
        PiecesLost++;

    }

    public void Reset()
    {
        PiecesLost = 0;
    }

    private void UpdateTowerHeightOnDebug()
    {
        if(DebugPanelManager.Instance)
        {
            switch (playerType.PlayerTag)
            {
                case PlayerTags.Player1:
                    DebugPanelManager.Instance.UpdatePlayer1TowerHeight(TowerManager.TowerHeight);
                    break;
                case PlayerTags.Player2:
                    DebugPanelManager.Instance.UpdatePlayer2TowerHeight(TowerManager.TowerHeight);
                    break;
            }
        }
    }

    private void UpdatePiecesLostOnDebug()
    {
        if(DebugPanelManager.Instance)
        {
            switch (playerType.PlayerTag)
            {
                case PlayerTags.Player1:
                    DebugPanelManager.Instance.BlocksLostP1 (PiecesLost);
                    break;
                case PlayerTags.Player2:
                    DebugPanelManager.Instance.BlocksLostP2(PiecesLost);
                    break;
            }
        }
    }    
}
