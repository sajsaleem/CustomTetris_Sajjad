using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IBlocksObjectPooler
{
    int DefaultCapacity { get; }
    int MaxCapacity { get; }
    GameObject BlocksParent { get; }
    IObjectPool<BaseBlockMovementHandler> Pool { get; }
    BaseBlockMovementHandler CreatePooledItem();
    void Initialize();
    void OnReturnedToPool(BaseBlockMovementHandler piece);
    void OnTakeFromPool(BaseBlockMovementHandler piece);
    void OnDestroyPoolObject(BaseBlockMovementHandler piece);
    void SetParent(Transform childBlock);
    void ReturnAllBlocksToPool();
}
