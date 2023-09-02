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
        if(Input.GetMouseButtonDown(0))
        {
            ScreenTouchBegan();        
        }

        else if(Input.GetMouseButton(0))
        {
            ManagePieceMovement();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            SreenTouchEnd();
        }
    }

    private void ManagePieceMovement()
    {
        endPressPosition = Input.mousePosition;

        Vector3 swipeDirection = endPressPosition - startPressPosition;

        //// Check if the swipe distance is larger than the threshold
        if (swipeDirection.x > 0.8f || swipeDirection.x < -0.8f)
        {
            // Calculate the movement amount based on swipe distance
            float moveAmount = swipeDirection.x * Time.deltaTime;

            // Move the parent GameObject (this will move the child object)
            //testingPiece.Translate(new Vector3(moveAmount, 0f, 0f));
            MoveObject(moveAmount);
            // Update the mouse start position for the next frame
            startPressPosition = endPressPosition;
        }
    }

    private void MoveObject(float moveAmount) => Managers.PiecesObjectPooler.ActivePiece.MovePieceSideWays(moveAmount);

    private void ScreenTouchBegan()
    {
        startPressPosition = Input.mousePosition;
        touchPhaseStart = Time.time;
    }

    private void SreenTouchEnd()
    {
        endPressPosition = Input.mousePosition;

        Vector3 swipeDirection = endPressPosition - startPressPosition;

        if ((Time.time - touchPhaseStart < tapInterval) && swipeDirection.magnitude < 0.2)
        {
            if (Managers.PiecesObjectPooler.ActivePiece != null)
                Managers.PiecesObjectPooler.ActivePiece.RotatePiece();
        }

        //swipe down
        else if ( (Time.time - touchPhaseStart < (tapInterval + 1f)) && swipeDirection.y > -0.5f && swipeDirection.x > -0.5f && swipeDirection.x < 0.5f)
        {
            Managers.PiecesObjectPooler.ActivePiece.FreeFallPiece();
        }

    }
}
