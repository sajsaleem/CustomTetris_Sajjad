using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerProgressTracker
{
    ITowerManager TowerManager { get; }
    int PiecesLost { get; }


    void RemoveBlock(Transform _transform);
    void AddBlock(Transform _transform);
    void Reset();
}
