using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IBlocksObjectPooler
{
    int DefaultCapacity { get; }
    int MaxCapacity { get; }
    BaseBlockMovementHandler ActivePiece { get; }
    IObjectPool<BaseBlockMovementHandler> Pool { get; }
    BaseBlockMovementHandler CreatePooledItem();
    void OnReturnedToPool(BaseBlockMovementHandler piece);
    void OnTakeFromPool(BaseBlockMovementHandler piece);
    void OnDestroyPoolObject(BaseBlockMovementHandler piece);
    void UpdateActivePieceReference(BaseBlockMovementHandler piece);
}
