using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IObjectPooler
{
    IPieceMovementHandler CreatePooledItem();
    void OnReturnedToPool();
    void OnTakeFromPool();
    void OnDestroyPoolObject();
}
