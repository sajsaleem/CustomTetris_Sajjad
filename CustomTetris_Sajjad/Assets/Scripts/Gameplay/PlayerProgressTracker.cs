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
        winCondition = Managers.LevelMaster.WinCondition();
        lossCondition = Managers.LevelMaster.LossCondition();
    }

    private void Update()
    {
        if(TowerManager.TowerHeight >= winCondition)
        {
            // Do Some Action;
        }

        if(PiecesLost >= lossCondition)
        {
            // Do Loss Action here;
        }

    }

    public void UpdatePiecesLost()
    {
        PiecesLost++;
    }

    public void Reset()
    {
        PiecesLost = 0;
    }
}
