using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class NullPiecesObjectPooler: IPiecesObjectPooler
{
    public static NullPiecesObjectPooler _instance;

    public static NullPiecesObjectPooler Instance
    {
        get
        {
            if (_instance == null)
                return new NullPiecesObjectPooler();

            return _instance;
        }
    }

    public int DefaultCapacity { get; private set; } = default;
    public int MaxCapacity { get; private set; } = default;
    public BasePieceMovementHandler ActivePiece { get; private set; } = default;
    public IObjectPool<BasePieceMovementHandler> Pool { get; private set; } = default;

    public BasePieceMovementHandler CreatePooledItem()
    {
        return Object.Instantiate(new GameObject("NullPiecesObjectPooler").AddComponent<NormalPieceMovementHandler>());
    }

    public void OnReturnedToPool(BasePieceMovementHandler piece)
    {

    }

    public void OnTakeFromPool(BasePieceMovementHandler piece)
    {

    }

    public void OnDestroyPoolObject(BasePieceMovementHandler piece)
    {

    }

    public void UpdateActivePieceReference(BasePieceMovementHandler piece)
    {

    }
}
