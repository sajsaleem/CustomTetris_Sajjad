using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerManager
{
    float TowerHeight { get; }
    void AddBlock(float value);
    void RemoveBlock(float value);
    void UpdateTowerHeight();
    void Reset();
}
