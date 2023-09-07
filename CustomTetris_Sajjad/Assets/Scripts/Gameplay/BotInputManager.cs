using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotInputManager : MonoBehaviour, IPlayerInputManager
{
    public float TapInterval { get; }
    public bool IsTouchActive { get; }

    public IBlockSpawner BlockSpawner { get; private set; } = default;

    private BaseBlockMovementHandler newBlock;

    private void OnEnable()
    {
        BlockSpawner = GetComponent<IBlockSpawner>();
        StartCoroutine("WaitForGameplayStart");
    }

    private void OnDisable()
    {
        StopCoroutine("WaitForGameplayStart");
    }

    public void MyUpdate()
    {

    }

    public void HandleMouseInput()
    {

    }

    public void HandleTouchInput()
    {

    }

    public void ManagePieceMovement()
    {
        if (newBlock != null)
            newBlock.MovePieceSideWays(5f);
    }

    public void ScreenTouchBegan(Vector3 _position)
    {

    }

    public void ScreenTouchEnd()
    {

    }

    public void RotateObject()
    {
        if(newBlock != null)
        {
            newBlock.RotatePiece();
        }
    }

    private IEnumerator WaitForGameplayStart()
    {
        yield return new WaitUntil(() => Managers.GameManager.GameState == GameStates.PlayState);

        yield return new WaitUntil(() => BlockSpawner.NewBlock != null);

        newBlock = BlockSpawner.NewBlock;

        while(Managers.GameManager.GameState == GameStates.PlayState)
        {
            StartCoroutine(DecisionMakingRoutine());

            yield return new WaitUntil(() => newBlock != BlockSpawner.NewBlock);

            newBlock = BlockSpawner.NewBlock;
        }

        yield break;
    }

    private IEnumerator DecisionMakingRoutine()
    {
        int movementDecision = Random.Range(2, 15);
        int rotationDecision = Random.Range(1, 3);

        int rotated = 0;
        int moved = 0;

        float decisionProbability = 0;


        while (rotated < rotationDecision || moved < movementDecision)
        {
            decisionProbability = GetRandomValue();

            if (decisionProbability > 0.5f)
            {
                ManagePieceMovement();
                moved++;
            }

            else if (decisionProbability <= 0.4f && rotated < rotationDecision)
            {
                rotated++;
                RotateObject();
                yield return new WaitForSeconds(0.3f);
            }

            yield return null;
        }

        yield break;
    }

    private float GetRandomValue()
    {
        return Random.value;
    }
}
