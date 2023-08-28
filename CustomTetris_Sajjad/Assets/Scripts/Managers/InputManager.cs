using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float tapInterval = default;

    private Vector3 startPressPosition;
    private Vector3 endPressPosition;
    private Vector2 currentSwipe;
    private float touchPhaseStart = default;

    private bool isTouchActive = true;

    private bool rotateObject = default;

    private float targetRotation = default;

    #region Testing Variables
    [SerializeField] private Transform testingPiece;
    [SerializeField] private Transform rotationPivot;
    #endregion

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

        //if(rotateObject)
        //{
        //    float rotateVal = Mathf.MoveTowardsAngle(rotationPivot.rotation.eulerAngles.z, targetRotation, 300 * Time.unscaledDeltaTime);
        //    rotationPivot.rotation = Quaternion.Euler(0f, 0f, rotateVal);

        //    if (Mathf.Approximately(rotateVal, targetRotation))
        //    {
        //        rotateObject = false;
        //    }
        //}
    }

    private void ManagePieceMovement()
    {
        endPressPosition = Input.mousePosition;

        Vector3 swipeDirection = endPressPosition - startPressPosition;

        //// Check if the swipe distance is larger than the threshold
        if (swipeDirection.magnitude > 0.5f)
        {
            // Calculate the movement amount based on swipe distance
            float moveAmount = swipeDirection.x * Time.deltaTime;

            //Debug.Log("Movement Amount: " + moveAmount);

            // Move the parent GameObject (this will move the child object)
            //testingPiece.Translate(new Vector3(moveAmount, 0f, 0f));

            // Update the mouse start position for the next frame
            startPressPosition = endPressPosition;
        }
    }


    private void ScreenTouchBegan()
    {
        startPressPosition = Input.mousePosition;
        touchPhaseStart = Time.time;
    }

    private void SreenTouchEnd()
    {
        if (Time.time - touchPhaseStart < tapInterval)
        {
            //targetRotation = rotationPivot.rotation.eulerAngles.z + 90.0f;

            //if (targetRotation >= 360.0f)
            //{
            //    targetRotation -= 360.0f;
            //}

            //rotateObject = true;
        }
    }

    //public void MoveHorizontal(Vector2 direction)
    //{
    //    //endPressPosition = Input.mousePosition;
    //    Vector3 swipeDirection = endPressPosition - startPressPosition;

    //    // Calculate the movement amount based on swipe distance
    //    float moveAmount = swipeDirection.x * Time.unscaledDeltaTime * 10f;

    //    // Move the parent GameObject (this will move the child object)
    //    transform.Translate(new Vector3(moveAmount, 0f, 0f));

    //    // Update the mouse start position for the next frame
    //    startPressPosition = endPressPosition;
    //}
}
