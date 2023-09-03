using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour ,IPlayerInputManager
{
    [SerializeField] private float tapInterval = default;
    [SerializeField] private bool isTouchActive = default;
    public float TapInterval { get => tapInterval; }
    public bool IsTouchActive { get => isTouchActive; }

    private Vector3 startPressPosition;
    private Vector3 endPressPosition;
    private float touchPhaseStart = default;

    void Update()
    {
        MyUpdate();
    }

    public void MyUpdate()
    {
        if (isTouchActive)
        {
#if UNITY_EDITOR
            HandleMouseInput();
#endif

#if UNITY_ANDROID || UNITY_IOS
            HandleTouchInput();
#endif
        }
    }

    public void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ScreenTouchBegan(Input.mousePosition);
        }

        else if (Input.GetMouseButton(0))
        {
            endPressPosition = Input.mousePosition;
            ManagePieceMovement();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            endPressPosition = Input.mousePosition;
            ScreenTouchEnd();
        }
    }

    public void HandleTouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startPressPosition = touch.position;
                endPressPosition = touch.position;
                touchPhaseStart = Time.time;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                endPressPosition = touch.position;
                ManagePieceMovement();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPressPosition = touch.position;
                ScreenTouchEnd();
            }
        }
    }

    public void ManagePieceMovement()
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

    public void ScreenTouchBegan(Vector3 _position)
    {
        startPressPosition = _position;
        touchPhaseStart = Time.time;
    }

    public void ScreenTouchEnd()
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

    private void MoveObject(float moveAmount)
    {
        if (Managers.PiecesObjectPooler.ActivePiece != null)
        {
            Managers.PiecesObjectPooler.ActivePiece.MovePieceSideWays(moveAmount);
        }
    }
}
