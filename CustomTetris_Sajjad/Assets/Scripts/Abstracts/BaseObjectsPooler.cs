using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseObjectsPooler : MonoBehaviour, IBlocksObjectPooler
{
    #region SerializedFields
    [SerializeField] private List<BaseBlockMovementHandler> blockPrefabs;
    [SerializeField] private int defaultCapacity = default;
    [SerializeField] private int maxCapacity = default;
    #endregion

    #region Private Fields
    private IObjectPool<BaseBlockMovementHandler> _pool;
    private BaseBlockMovementHandler activePiece = default;
    #endregion

    #region Properties

    public IObjectPool<BaseBlockMovementHandler> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<BaseBlockMovementHandler>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false,defaultCapacity,maxCapacity);
            }

            return _pool;
        }
    }

    public int DefaultCapacity => defaultCapacity;
    public int MaxCapacity => maxCapacity;
    public BaseBlockMovementHandler ActivePiece => activePiece;
    #endregion

    #region Virtual Functions

    public virtual BaseBlockMovementHandler CreatePooledItem()
    {
        BaseBlockMovementHandler piecePrefab = blockPrefabs[Random.Range(0, blockPrefabs.Count - 1)];
        var instantiatedObject = Instantiate(piecePrefab);
        UpdateActivePieceReference(instantiatedObject);
        return instantiatedObject;
    }

    public virtual void OnTakeFromPool(BaseBlockMovementHandler block)
    {
        block.gameObject.SetActive(true);
        UpdateActivePieceReference(block);
    }

    public virtual void OnReturnedToPool(BaseBlockMovementHandler piece)
    {
        piece.gameObject.SetActive(false);
    }

    public virtual void OnDestroyPoolObject(BaseBlockMovementHandler piece)
    {
        Destroy(piece.gameObject);
    }

    public virtual void UpdateActivePieceReference(BaseBlockMovementHandler block)
    {
        this.activePiece = block;
    }

    #endregion
}
