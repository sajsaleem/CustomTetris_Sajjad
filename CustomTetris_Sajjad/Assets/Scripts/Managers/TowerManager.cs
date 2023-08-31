using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour, ITowerManager
{

    public float TowerHeight { get; private set; } = default;

    float blockHeightY = default;

    public void AddBlock(float value)
    {
        if(value > TowerHeight)
        {
            float newVal = value - TowerHeight;
            TowerHeight += newVal;

            UpdateTowerHeight();
        }
    }

    public void RemoveBlock(float value)
    {
        float newVal = value - TowerHeight;
        TowerHeight -= newVal;
        UpdateTowerHeight();
    }

    public void UpdateTowerHeight()
    {
        //Update UI end;
        Debug.Log("<color=green> Tower Height: </color>" + TowerHeight);
    }

    public void Reset()
    {
        TowerHeight = 0;
    }
}
