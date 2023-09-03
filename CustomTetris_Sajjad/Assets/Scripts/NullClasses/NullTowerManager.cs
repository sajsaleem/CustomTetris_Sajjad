using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullTowerManager : ITowerManager
{
    public static NullTowerManager _instance;

    public static NullTowerManager Instance
    {
        get
        {
            if (_instance == null)
                return new NullTowerManager();

            return _instance;
        }
    }

    public float TowerHeight { get; private set; } = default;

    //public void AddBlock(float value)
    //{

    //}

    //public void RemoveBlock(float value)
    //{

    //}

    public void AddBlock(Transform _transform)
    {

    }

    public void RemoveBlock(Transform _transform)
    {

    }

    public void UpdateTowerHeight()
    {

    }

    public void Reset()
    {

    }
}
