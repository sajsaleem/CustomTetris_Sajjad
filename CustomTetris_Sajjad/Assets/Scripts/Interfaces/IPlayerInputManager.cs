using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInputManager
{

    float TapInterval { get; }
    bool IsTouchActive { get; }

    IBlockSpawner BlockSpawner { get; }

    void MyUpdate();
    void HandleMouseInput();
    void HandleTouchInput();
    void ManagePieceMovement();
    void RotateObject();
    void ScreenTouchBegan(Vector3 _position);
    void ScreenTouchEnd();
}
