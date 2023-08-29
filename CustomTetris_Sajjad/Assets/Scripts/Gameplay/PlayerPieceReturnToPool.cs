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
        screenBounds = ScreenBoundsStaticClass.GetScreenBounds();
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
        //Managers.PiecesObjectPooler.UpdateActivePieceReference(null);
        pieceMovementHandler.Reset();
        //movementHandlerPool.Release(pieceMovementHandler);
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            OnOutOfBounds();
        }
    }
}
