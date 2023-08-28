using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    private Vector2 Screenbounds;

    private float leftPositionX , RightPositionX;

    // Start is called before the first frame update
    void Start()
    {
        leftPositionX = transform.position.x - (transform.localScale.x / 2);
        RightPositionX = transform.position.x + (transform.localScale.x / 2);

        StartCoroutine(_Spawner());
    }

    private void SpawnPiece()
    {
        var newPiece = Managers.PiecesObjectPooler.Pool.Get();
        float randomXPosition = Random.Range(leftPositionX, RightPositionX);
        newPiece.transform.position = new Vector3(randomXPosition, transform.position.y, newPiece.transform.position.z);
        newPiece.Initialize();
    }

    private IEnumerator _Spawner()
    {
        while(true)
        {
            SpawnPiece();

            yield return new WaitForSeconds(7);
        }

        yield break;
    }

}
