using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for handling tower height and other tower related activities;

public class TowerManager : MonoBehaviour, ITowerManager
{

    public float TowerHeight { get; private set; } = default;

    private List<Transform> towerBlocks = new List<Transform>();

    private void OnDisable()
    {
        Reset();
    }

    public void AddBlock(Transform _transform)
    {
        towerBlocks.Add(_transform);
        UpdateTowerHeight();
    }

    public void RemoveBlock(Transform _transform)
    {
        towerBlocks.Remove(_transform);
        UpdateTowerHeight();
    }

    public void UpdateTowerHeight()
    {
        //Update UI end;
        float maxheight = 0;
        float placedheight = 0;
        float height = 0;
        float surfaceHeight = Managers.LevelMaster.SurfaceHeight();

        for (int i = 0; i < towerBlocks.Count; i++)
        {
            height = CalculationsStaticClass.GetVerticalChildrenScale(towerBlocks[i]);
            placedheight = CalculationsStaticClass.GetMaxHeightOfObject(height, towerBlocks[i].position.y - surfaceHeight);

            if (placedheight > maxheight)
                maxheight = placedheight;
        }

        TowerHeight = Mathf.Ceil(maxheight);
    }

    public void Reset()
    {
        TowerHeight = 0;
        towerBlocks.Clear();
    }
}
