using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PieceSpawner : MonoBehaviour
{
    private Vector2 Screenbounds;

    private float leftPositionX , RightPositionX;

    BasePieceMovementHandler newPiece;

    // Start is called before the first frame update
    void Start()
    {
        leftPositionX = transform.position.x - (transform.localScale.x / 2);
        RightPositionX = transform.position.x + (transform.localScale.x / 2);
        //SpawnPiece();

        StartCoroutine(_Spawner());
    }

    public void SpawnPiece()
    {
        Debug.Log("Spawn Piece");

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
        while (true)
        {
            SpawnPiece();

            Debug.Log("IsPlaced: " + Managers.PiecesObjectPooler.ActivePiece.IsPlaced);

            yield return new WaitUntil(() => newPiece.IsPlaced);
        }

        yield break;
    }

}
