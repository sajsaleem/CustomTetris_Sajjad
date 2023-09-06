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
    private GameObject blocksParent;
    #endregion

    #region Properties

    public IObjectPool<BaseBlockMovementHandler> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<BaseBlockMovementHandler>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, defaultCapacity, maxCapacity);
            }

            return _pool;
        }
    }

    public int DefaultCapacity { get => defaultCapacity; }
    public int MaxCapacity { get => maxCapacity;}
    public GameObject BlocksParent { get => blocksParent; }
    #endregion

    #region Virtual Functions

    public virtual void Initialize()
    {
        blocksParent = new GameObject("BlocksParent");
    }

    public virtual BaseBlockMovementHandler CreatePooledItem()
    {
        BaseBlockMovementHandler piecePrefab = blockPrefabs[Random.Range(0, blockPrefabs.Count - 1)];
        var instantiatedObject = Instantiate(piecePrefab);
        return instantiatedObject;
    }

    public virtual void OnTakeFromPool(BaseBlockMovementHandler block)
    {
        block.gameObject.SetActive(true);
    }

    public virtual void OnReturnedToPool(BaseBlockMovementHandler piece)
    {
        piece.gameObject.SetActive(false);
    }

    public virtual void OnDestroyPoolObject(BaseBlockMovementHandler piece)
    {
        Destroy(piece.gameObject);
    }

    public virtual void SetParent(Transform childBlock)
    {
        childBlock.transform.SetParent(BlocksParent.transform);
    }

    public virtual void ReturnAllBlocksToPool()
    {
        BaseBlockMovementHandler[] childBlocks = BlocksParent.GetComponentsInChildren<BaseBlockMovementHandler>();

        for(int i = 0; i < childBlocks.Length; i++)
        {
            Pool.Release(childBlocks[i]);
        }
    }

    #endregion
}
