using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IPiecesObjectPooler
{
    int DefaultCapacity { get; }
    int MaxCapacity { get; }
    BasePieceMovementHandler ActivePiece { get; }
    IObjectPool<BasePieceMovementHandler> Pool { get; }
    BasePieceMovementHandler CreatePooledItem();
    void OnReturnedToPool(BasePieceMovementHandler piece);
    void OnTakeFromPool(BasePieceMovementHandler piece);
    void OnDestroyPoolObject(BasePieceMovementHandler piece);
    void UpdateActivePieceReference(BasePieceMovementHandler piece);
}
