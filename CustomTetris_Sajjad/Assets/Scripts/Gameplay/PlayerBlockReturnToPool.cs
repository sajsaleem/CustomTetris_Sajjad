using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/* Class that is responsible for returning block to the pool once it's out of the bounds of camera */

public class PlayerBlockReturnToPool : BaseReturnToPool
{
    private BaseBlockMovementHandler blockMovementHandler;

    private void Start()
    {
        blockMovementHandler = GetComponent<BaseBlockMovementHandler>();
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnOutOfBounds()
    {
        base.OnOutOfBounds();
        Managers.BlockObjectsPooler.Pool.Release(blockMovementHandler);
        blockMovementHandler.RemoveBlockHeightFromTower();
        blockMovementHandler.Reset();
    }

    private void Update()
    {
        if (transform.position.y < 0 || transform.position.x < CalculationsStaticClass.GetHorizontalViewportToWorldPoint(0) || transform.position.x > CalculationsStaticClass.GetHorizontalViewportToWorldPoint(1))
        {
            ManageBlockState();
            OnOutOfBounds();
        }
    }

    private void ManageBlockState()
    {
        if (blockMovementHandler.BlockState == BlockState.Falling)
            blockMovementHandler.UpdatePieceState( BlockState.FellOutOfBounds);
    }
}
