using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraMaster
{
    void Initialize();
    void ShowFinishLine(float value);
    void MoveUp(PlayerTags tag, float height);
    void MoveDown(PlayerTags tag, float height);
    void SetCamerasActiveStatus(GameModeType gameModeType);
    void Reset();

}
