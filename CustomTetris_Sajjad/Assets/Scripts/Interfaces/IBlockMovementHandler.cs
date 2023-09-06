using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IBlockMovementHandler
{
    bool IsPlaced { get; }
    bool MyRigidBody { get; }
    bool IsActive { get; }
    BlockState BlockState { get; }
    BlockType BlockType { get; }
    Vector3 LocalScale { get; }
    Vector3 Position { get; }
    BaseBlockSettings BlockSettings { get; }

    void Initialize(IPlayerProgressTracker playerProgressTracker, Transform highlighter);
    void RotatePiece();
    void MovePieceSideWays(float value);
    void Reset();
}
