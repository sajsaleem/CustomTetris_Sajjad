using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PieceSpawner : MonoBehaviour
{
    private float leftPositionX , RightPositionX;

    BasePieceMovementHandler newPiece;

    // Start is called before the first frame update
    void Start()
    {
        leftPositionX = transform.position.x - (transform.localScale.x / 2);
        RightPositionX = transform.position.x + (transform.localScale.x / 2);
        StartCoroutine(_Spawner());
    }


    public void SpawnPiece()
    {
        if (PoolIsNull())
            return;

        newPiece = Managers.PiecesObjectPooler.Pool.Get();
        float randomXPosition = Random.Range(leftPositionX, RightPositionX);
        newPiece.transform.position = new Vector3(randomXPosition, transform.position.y, newPiece.transform.position.z);
        newPiece.Initialize();
    }

    private bool PoolIsNull()
    {
        if (Managers.PiecesObjectPooler.Pool == null)
            return true;

        return false;
    }

    private IEnumerator _Spawner()
    {
        yield return new WaitUntil(() => Managers.GameManager.GameState == GameStates.GameplayState);
        while (true)
        {
            SpawnPiece();

            Debug.Log("IsPlaced: " + Managers.PiecesObjectPooler.ActivePiece.IsPlaced);

            yield return new WaitUntil(() => newPiece.IsPlaced);
        }

        yield break;
    }

}
