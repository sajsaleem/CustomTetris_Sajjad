using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for(int i = 0; i < towerBlocks.Count; i++)
        {
            Transform heighestChild = CalculationsStaticClass.GetHeighestTransformInChildren(towerBlocks[i]);
            placedheight = CalculationsStaticClass.GetObjectHeight(heighestChild);

            if (placedheight > maxheight)
                maxheight = placedheight;
        }

        TowerHeight = Mathf.Ceil(maxheight);

        Debug.Log("<color=green> Tower Height: </color>" + TowerHeight);
    }

    public void Reset()
    {
        TowerHeight = 0;
        towerBlocks.Clear();
    }
}
