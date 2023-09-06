using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour,ICameraController
{
    private bool isMovingToFinishLine = default;
    private bool isMovingToInitialPos = default;
    private bool moveUp, moveDown;
    private float camVerticalHeight = default;
    private float moveAmountToFinishLine = default;
    private float moveUpAmount = default;
    private float moveDownAmount = default;

    private Vector3 initialPosition;

    public void Initialize()
    {
        initialPosition = transform.position;
    }

    public void ShowFinishLine(float finishLineYPos)
    {
        float camVerticalHeight = CalculationsStaticClass.GetVerticalViewportToWorldPoint(1);

        float difference = finishLineYPos - camVerticalHeight;

        if(difference > 0)
        {
            isMovingToFinishLine = true;
            moveAmountToFinishLine = transform.position.y + difference + 5f;
        }

        StartCoroutine(_MoveToFinishLine());
    }

    public void MoveUp(float target)
    {
        if(target > transform.position.y + 2.5f)
        {
            moveUp = true;
            moveUpAmount = target;//- transform.position.y;
        }
    }
    public void MoveDown(float target)
    {
        if(target < transform.position.y  && target >= initialPosition.y)
        {
            moveDownAmount = target;
        }
    }

    public void Reset()
    {
        transform.position = initialPosition;
    }

    private IEnumerator _MoveToFinishLine()
    {
        yield return new WaitForSeconds(1f);

        while(isMovingToFinishLine)
        {
            float lerpMov = Mathf.MoveTowards(transform.position.y, moveAmountToFinishLine, 1.5f * Time.fixedDeltaTime);

            transform.position = new Vector3(transform.position.x, lerpMov, transform.position.z);

            if (lerpMov >= moveAmountToFinishLine)
            {
                isMovingToFinishLine = false;
                isMovingToInitialPos = true;
            }
            yield return null;
        }

        StartCoroutine(_MoveBackToInitialPosition());
        yield break;

    }

    private IEnumerator _MoveBackToInitialPosition()
    {
        yield return new WaitForSeconds(1f);

        while(isMovingToInitialPos)
        {
            float lerpMov = Mathf.MoveTowards(transform.position.y, initialPosition.y,  1.5f * Time.fixedDeltaTime);

            transform.position = new Vector3(transform.position.x, lerpMov, transform.position.z);

            if (lerpMov <= initialPosition.y)
            {
                isMovingToInitialPos = false;
            }

            yield return null;
        }

        yield return new WaitForSeconds(1);

        Managers.GameManager.UpdateGameState(GameStates.PlayState);

        yield break;
    }

    private void LateUpdate()
    {
        if(moveUp)
        {
            float lerpY = Mathf.MoveTowards(transform.position.y, moveUpAmount, 2 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, lerpY, transform.position.z);

            if (lerpY >= moveUpAmount)
                moveUp = false;
        }
    }
}
