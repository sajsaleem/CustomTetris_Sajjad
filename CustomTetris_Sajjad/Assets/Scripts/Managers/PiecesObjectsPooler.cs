using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesObjectsPooler : BaseObjectsPooler
{
    public override BasePieceMovementHandler CreatePooledItem()
    {
        return base.CreatePooledItem();
    }

    public override void OnTakeFromPool(BasePieceMovementHandler piece)
    {
        base.OnTakeFromPool(piece);
    }

    public override void OnReturnedToPool(BasePieceMovementHandler piece)
    {
        base.OnReturnedToPool(piece);
    }

    public override void OnDestroyPoolObject(BasePieceMovementHandler piece)
    {
        base.OnDestroyPoolObject(piece);
    }
}
