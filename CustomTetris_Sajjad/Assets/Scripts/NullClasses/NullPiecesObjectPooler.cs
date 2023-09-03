using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class NullBlocksObjectPooler: IBlocksObjectPooler
{
    public static NullBlocksObjectPooler _instance;

    public static NullBlocksObjectPooler Instance
    {
        get
        {
            if (_instance == null)
                return new NullBlocksObjectPooler();

            return _instance;
        }
    }

    public int DefaultCapacity { get; private set; } = default;
    public int MaxCapacity { get; private set; } = default;
    public BaseBlockMovementHandler ActivePiece { get; private set; } = default;
    public IObjectPool<BaseBlockMovementHandler> Pool { get; private set; } = default;

    public BaseBlockMovementHandler CreatePooledItem()
    {
        return Object.Instantiate(new GameObject("NullPiecesObjectPooler").AddComponent<BaseBlockMovementHandler>());
    }

    public void OnReturnedToPool(BaseBlockMovementHandler piece)
    {

    }

    public void OnTakeFromPool(BaseBlockMovementHandler piece)
    {

    }

    public void OnDestroyPoolObject(BaseBlockMovementHandler piece)
    {

    }

    public void UpdateActivePieceReference(BaseBlockMovementHandler piece)
    {

    }
}
