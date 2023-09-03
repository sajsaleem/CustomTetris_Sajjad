using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float tapInterval = default;

    private Vector3 startPressPosition;
    private Vector3 endPressPosition;
    private float touchPhaseStart = default;

    private bool isTouchActive = true;

    // Update is called once per frame
    void Update()
    {
        if(isTouchActive)
        {
            ManageMouseInput();
        }
    }

    private void ManageMouseInput()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            ScreenTouchBegan(Input.mousePosition);        
        }

        else if(Input.GetMouseButton(0))
        {
            endPressPosition = Input.mousePosition;
            ManagePieceMovement();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            endPressPosition = Input.mousePosition;
            SreenTouchEnd();
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        HandleTouchControls();
#endif

    }

    private void HandleTouchControls()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                startPressPosition = touch.position;
                endPressPosition = touch.position;
                touchPhaseStart = Time.time;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                endPressPosition = touch.position;
                ManagePieceMovement();
            }

            if(touch.phase == TouchPhase.Ended)
            {
                endPressPosition = touch.position;
                SreenTouchEnd();
            }
        }
    }

    private void ManagePieceMovement()
    {

        Vector3 swipeDirection = (endPressPosition - startPressPosition).normalized;

        //// Check if the swipe distance is larger than the threshold
        if (swipeDirection.x >= 0.5f || swipeDirection.x <= -0.5f)
        {
            MoveObject(swipeDirection.x);

            // Update the mouse start position for the next frame
            startPressPosition = endPressPosition;
        }
    }

    private void MoveObject(float moveAmount)
    {
        if(Managers.PiecesObjectPooler.ActivePiece != null)
        {
            Managers.PiecesObjectPooler.ActivePiece.MovePieceSideWays(moveAmount);
        }
    } 

    private void ScreenTouchBegan(Vector3 position)
    {
        startPressPosition = position;
        touchPhaseStart = Time.time;
    }

    private void SreenTouchEnd()
    {

        Vector3 swipeDirection = endPressPosition - startPressPosition;

        if ((Time.time - touchPhaseStart < tapInterval) && swipeDirection.magnitude <= 0.3)
        {
            if (Managers.PiecesObjectPooler.ActivePiece != null)
                Managers.PiecesObjectPooler.ActivePiece.RotatePiece();
        }

        //swipe down
        //else if ( (Time.time - touchPhaseStart < (tapInterval + 1f)) && swipeDirection.y > -0.5f && swipeDirection.x > -0.5f && swipeDirection.x < 0.5f)
        //{
        //    Managers.PiecesObjectPooler.ActivePiece.FreeFallPiece();
        //}

    }
}
