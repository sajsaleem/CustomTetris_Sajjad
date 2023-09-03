using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerManager
{
    float TowerHeight { get; }
    //void AddBlock(float value);
    void AddBlock(Transform _transform);
    //void RemoveBlock(float value);
    void RemoveBlock(Transform _transform);
    void UpdateTowerHeight();
    void Reset();
}
