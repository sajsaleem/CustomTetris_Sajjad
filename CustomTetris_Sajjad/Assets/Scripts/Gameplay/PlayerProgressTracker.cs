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

    //private void Update()
    //{
    //    if(TowerManager.TowerHeight >= winCondition)
    //    {
    //        // Do Some Action;
    //        Managers.ResultManager.UpdateWinner(playerType.PlayerTag.ToString());
    //    }

    //    if(PiecesLost >= lossCondition)
    //    {
    //        // Do Loss Action here;
    //        Managers.ResultManager.UpdateLooser(playerType.PlayerTag.ToString());
    //    }
    //}

    public void RemoveBlock(Transform _transform)
    {
        // removes block from tower;
        TowerManager.RemoveBlock(_transform);
        UpdatePiecesLost();

        if(PiecesLost >= lossCondition)
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

        if (TowerManager.TowerHeight >= winCondition)
        {
            // Do Win Action;
            Managers.ResultManager.UpdateWinner(playerType.PlayerTag.ToString());
            Managers.GameManager.EndPlay();
        }
    }

    private void UpdatePiecesLost()
    {
        PiecesLost++;
    }

    public void Reset()
    {
        PiecesLost = 0;
    }
}
