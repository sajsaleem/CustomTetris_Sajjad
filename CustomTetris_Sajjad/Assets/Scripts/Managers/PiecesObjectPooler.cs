using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PiecesObjectPooler : MonoBehaviour
{
    [SerializeField] private List<BasePieceMovementHandler> piecesPrefabs;

    private IObjectPool<BasePieceMovementHandler> _pool;

    public IObjectPool<BasePieceMovementHandler> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<BasePieceMovementHandler>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, 100, 200);
            }

            return _pool;
        }
    }

    BasePieceMovementHandler CreatePooledItem()
    {
        BasePieceMovementHandler piecePrefab = piecesPrefabs[Random.Range(0, piecesPrefabs.Count - 1)];

        var instantiatedObject = Instantiate(piecePrefab);

        return instantiatedObject;
    }

    void OnTakeFromPool(BasePieceMovementHandler piece)
    {
        piece.gameObject.SetActive(true);
    }

    void OnReturnedToPool(BasePieceMovementHandler piece)
    {
        piece.gameObject.SetActive(false);
    }

    void OnDestroyPoolObject(BasePieceMovementHandler piece)
    {
        Destroy(piece.gameObject);
    }
}
