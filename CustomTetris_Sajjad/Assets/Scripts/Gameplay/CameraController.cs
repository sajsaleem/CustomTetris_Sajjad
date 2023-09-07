using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour,ICameraController
{
    [SerializeField] private float startSequenceSpeed = 10;
    [SerializeField] private float cameraFollowSpeed = 2;

    private bool isMovingToFinishLine = default;
    private bool isMovingToInitialPos = default;
    private bool moveUp, moveDown;
    private float moveAmountToFinishLine = default;
    private float moveUpAmount = default;
    private float moveDownAmount = default;
    private float waitBeforeMoveToInitial = default;

    private Vector3 initialPosition;

    public void Initialize()
    {
        initialPosition = transform.position;
    }

    //Handles starting sequence where camera moves till finish line and back to original position;
    public void ShowFinishLine(float finishLineYPos)
    {
        float camVerticalHeight = CalculationsStaticClass.GetVerticalViewportToWorldPoint(1);

        float difference = finishLineYPos - camVerticalHeight;

        if(difference > 0)
        {
            isMovingToFinishLine = true;
            moveAmountToFinishLine = transform.position.y + difference + 5f;
        }

        isMovingToFinishLine = true;
        isMovingToInitialPos = false;
    }

    // Moves camera in the upward direction based on the tower's height;
    public void MoveUp(float target)
    {
        if (target > (transform.position.y / 1.5f) && !moveUp)
        {
            moveUp = true;
            moveUpAmount = transform.position.y + 5f;
        }
    }

    //Moves camera down if tower collapses;
    public void MoveDown(float target)
    {
        if(target < transform.position.y  && target >= initialPosition.y && !moveDown)
        {
            moveDown = true;
            moveDownAmount = target;
        }
    }

    //Resets all camera properties to initial;
    public void Reset()
    {
        transform.position = initialPosition;
        isMovingToFinishLine = default;
        isMovingToInitialPos = default;
        moveUp = false;
        moveDown = false;
    }

    private void LateUpdate()
    {
        if (moveUp)
        {
            float lerpY = Mathf.MoveTowards(transform.position.y, moveUpAmount, cameraFollowSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, lerpY, transform.position.z);

            if (Mathf.Approximately(lerpY, moveUpAmount))
                moveUp = false;
        }

        if (moveDown)
        {
            float lerpY = Mathf.MoveTowards(transform.position.y, moveDownAmount, cameraFollowSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, lerpY, transform.position.z);

            if (Mathf.Approximately(lerpY, moveDownAmount))
                moveUp = false;
        }
    }

    private void Update()
    {
        if(isMovingToFinishLine)
        {
            MovingToTarget(moveAmountToFinishLine);
        }

        if(isMovingToInitialPos && waitBeforeMoveToInitial < Time.time)
        {
            MovingToInitialPosition(initialPosition.y);
        }
    }

    private void MovingToTarget(float moveAmount)
    {
        float lerpMov = Mathf.MoveTowards(transform.position.y, moveAmount, startSequenceSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, lerpMov, transform.position.z);

        if (Mathf.Approximately(lerpMov, moveAmount)) 
        {
            isMovingToFinishLine = false;
            isMovingToInitialPos = true;
            waitBeforeMoveToInitial = Time.time + 0.5f;
        }
    }

    private void MovingToInitialPosition(float moveAmount)
    {
        float lerpMov = Mathf.MoveTowards(transform.position.y, moveAmount, startSequenceSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, lerpMov, transform.position.z);

        if (Mathf.Approximately(lerpMov, moveAmount))
        {
            isMovingToInitialPos = false;
            Managers.GameManager.StartGameplay();
        }
    }
}
