using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlockMovementHandler : BaseBlockMovementHandler
{
    private float leftBorder = default;
    private float rightBoder = default;

    private void OnEnable()
    {
        MyEnable();
    }

    private void Update()
    {
        MyUpdate();
    }

    public override void MyEnable()
    {
        base.MyEnable();

        SetMovementArea();
    }

    public override void Initialize(IPlayerProgressTracker playerProgressTracker , Transform highlighter)
    {
        base.Initialize(playerProgressTracker, highlighter);
    }

    public override void MovePieceSideWays(float moveAmount)
    {
        base.MovePieceSideWays(moveAmount);

        if(transform.position.x > rightBoder)
        {
            transform.position = new Vector3(rightBoder, transform.position.y, transform.position.z);
        }

        if(transform.position.x < leftBorder)
        {
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);

        }
    }

    public override void RotatePiece()
    {
        base.RotatePiece();
    }

    public override void MyUpdate()
    {
        base.MyUpdate();
    }

    public override void Reset()
    {
        base.Reset();
    }

    private void SetMovementArea()
    {
        Vector2 horizontalMovementArea = BlockSettings.blockData.horizontalMovementArea;
        leftBorder = CalculationsStaticClass.GetHorizontalViewportToWorldPoint(horizontalMovementArea.x);
        rightBoder = CalculationsStaticClass.GetHorizontalViewportToWorldPoint(horizontalMovementArea.y);
    }
}
