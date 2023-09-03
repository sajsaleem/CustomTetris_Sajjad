using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentSetter : MonoBehaviour
{
    [SerializeField] private Transform surface;
    [SerializeField] private Transform finishLine;

    private LevelData _levelData;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _levelData = Managers.LevelMaster.GetLevel();
        surface.position = _levelData.surfacePosition;
        surface.localScale = _levelData.surfaceDimensions;
        float finishLineYPos = CalculationsStaticClass.GetVerticalDistance(_levelData.winCondition, surface.position.y, surface.localScale.y);
        finishLine.position = new Vector3(finishLine.position.x, finishLineYPos, finishLine.position.z);
    }
}
