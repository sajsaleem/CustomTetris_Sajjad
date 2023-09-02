using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IPieceMovementHandler
{
    bool IsPlaced { get; }
    bool MyRigidBody { get; }
    bool IsActive { get; }
    PieceState PieceState { get; }
    Vector3 LocalScale { get; }
    Vector3 Position { get; }

    void Initialize(IPlayerProgressTracker playerProgressTracker);
    void RotatePiece();
    void MovePieceSideWays(float value);
    void Reset();
}
