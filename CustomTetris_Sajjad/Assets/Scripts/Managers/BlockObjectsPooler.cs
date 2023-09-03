using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObjectsPooler : BaseObjectsPooler
{
    public override BaseBlockMovementHandler CreatePooledItem()
    {
        return base.CreatePooledItem();
    }

    public override void OnTakeFromPool(BaseBlockMovementHandler piece)
    {
        base.OnTakeFromPool(piece);
    }

    public override void OnReturnedToPool(BaseBlockMovementHandler piece)
    {
        base.OnReturnedToPool(piece);
    }

    public override void OnDestroyPoolObject(BaseBlockMovementHandler piece)
    {
        base.OnDestroyPoolObject(piece);
    }
}
