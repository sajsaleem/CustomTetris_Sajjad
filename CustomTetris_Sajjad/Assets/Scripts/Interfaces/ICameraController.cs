using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraController
{
    void Initialize();
    void ShowFinishLine(float finishLineYPos);
    void MoveUp(float target);
    void MoveDown(float target);
    void Reset();
}
