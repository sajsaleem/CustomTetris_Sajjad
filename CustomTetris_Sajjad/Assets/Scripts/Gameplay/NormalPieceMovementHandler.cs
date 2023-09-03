using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPieceMovementHandler : BasePieceMovementHandler
{

    private void OnEnable()
    {
        MyEnable();
    }

    private void Update()
    {
        MyUpdate();
    }

    public override void MyEnable()
    {
        base.MyEnable();
    }

    public override void Initialize(IPlayerProgressTracker playerProgressTracker)
    {
        base.Initialize(playerProgressTracker);
    }

    public override void MovePieceSideWays(float moveAmount)
    {
        base.MovePieceSideWays(moveAmount);
    }

    public override void RotatePiece()
    {
        base.RotatePiece();
    }

    public override void FreeFallPiece()
    {
        base.FreeFallPiece();
    }

    public override void MyUpdate()
    {
        base.MyUpdate();
    }

    public override void Reset()
    {
        base.Reset();
    }
}
