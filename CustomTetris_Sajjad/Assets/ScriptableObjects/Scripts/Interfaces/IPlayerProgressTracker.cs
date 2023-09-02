using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerProgressTracker
{
    ITowerManager TowerManager { get; }
    int PiecesLost { get; }

    void UpdatePiecesLost();
    void Reset();
}
