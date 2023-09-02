using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseObjectsPooler : MonoBehaviour, IPiecesObjectPooler
{
    #region SerializedFields
    [SerializeField] private List<BasePieceMovementHandler> piecesPrefabs;
    [SerializeField] private int defaultCapacity = default;
    [SerializeField] private int maxCapacity = default;
    #endregion

    #region Private Fields
    private IObjectPool<BasePieceMovementHandler> _pool;
    private BasePieceMovementHandler activePiece = default;
    #endregion

    #region Properties

    public IObjectPool<BasePieceMovementHandler> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<BasePieceMovementHandler>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false,defaultCapacity,maxCapacity);
            }

            return _pool;
        }
    }

    public int DefaultCapacity => defaultCapacity;
    public int MaxCapacity => maxCapacity;
    public BasePieceMovementHandler ActivePiece => activePiece;
    #endregion

    #region Virtual Functions

    public virtual BasePieceMovementHandler CreatePooledItem()
    {
        BasePieceMovementHandler piecePrefab = piecesPrefabs[Random.Range(0, piecesPrefabs.Count - 1)];
        var instantiatedObject = Instantiate(piecePrefab);
        UpdateActivePieceReference(instantiatedObject);
        return instantiatedObject;
    }

    public virtual void OnTakeFromPool(BasePieceMovementHandler piece)
    {
        piece.gameObject.SetActive(true);
        UpdateActivePieceReference(piece);
    }

    public virtual void OnReturnedToPool(BasePieceMovementHandler piece)
    {
        piece.gameObject.SetActive(false);
    }

    public virtual void OnDestroyPoolObject(BasePieceMovementHandler piece)
    {
        Destroy(piece.gameObject);
    }

    public virtual void UpdateActivePieceReference(BasePieceMovementHandler piece)
    {
        this.activePiece = piece;
    }

    #endregion
}
