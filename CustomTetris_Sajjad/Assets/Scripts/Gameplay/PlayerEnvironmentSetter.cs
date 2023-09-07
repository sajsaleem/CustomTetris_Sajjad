using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnvironmentSetter : MonoBehaviour
{
    [SerializeField] private Transform surface;
    [SerializeField] private Transform finishLine;

    private LevelData _levelData;

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        _levelData = Managers.LevelMaster.GetLevel();
        surface.position = _levelData.surfacePosition;
        surface.localScale = _levelData.surfaceDimensions;

        // Calculates finishline position by using wincondition value and by using dimensions of surface;
        float finishLineYPos = CalculationsStaticClass.GetVerticalDistance(_levelData.winCondition, surface.position.y, surface.localScale.y);
        finishLine.position = new Vector3(finishLine.position.x, finishLineYPos, finishLine.position.z);
        Managers.CameraMaster.ShowFinishLine(finishLine.position.y);
    }
}
