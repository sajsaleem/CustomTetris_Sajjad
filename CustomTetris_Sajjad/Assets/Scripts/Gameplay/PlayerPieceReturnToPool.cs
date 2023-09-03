using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerPieceReturnToPool : BaseReturnToPool
{
    //ObjectPool<BasePieceMovementHandler> movementHandlerPool;

    private BasePieceMovementHandler pieceMovementHandler;

    private Vector3 screenBounds;

    private void Start()
    {
        screenBounds = CalculationsStaticClass.GetScreenBounds();
        pieceMovementHandler = GetComponent<BasePieceMovementHandler>();
        Debug.Log("ScreenBoundY: " + -screenBounds.y);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnOutOfBounds()
    {
        base.OnOutOfBounds();
        Managers.PiecesObjectPooler.Pool.Release(pieceMovementHandler);
        pieceMovementHandler.RemoveBlockHeightFromTower();
        pieceMovementHandler.Reset();
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            OnOutOfBounds();
        }
    }
}
