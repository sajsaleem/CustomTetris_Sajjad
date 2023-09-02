using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BlockSpawner : MonoBehaviour
{
    private float leftPositionX , RightPositionX;

    [SerializeField] private UnityLayers unityLayer;
    [SerializeField] private Transform blockSpawner;

    private IPlayerProgressTracker playerProgressTracker;

    BasePieceMovementHandler newPiece;

    // Start is called before the first frame update
    void Start()
    {
        leftPositionX = blockSpawner.position.x - (blockSpawner.localScale.x / 2);
        RightPositionX = blockSpawner.position.x + (blockSpawner.localScale.x / 2);
        playerProgressTracker = GetComponent<IPlayerProgressTracker>();
        StartCoroutine(_Spawner());
    }


    public void SpawnPiece()
    {
        if (PoolIsNull())
            return;

        newPiece = Managers.PiecesObjectPooler.Pool.Get();
        newPiece.gameObject.layer = (int)unityLayer;
        float randomXPosition = Random.Range(leftPositionX, RightPositionX);
        newPiece.transform.position = new Vector3(randomXPosition, blockSpawner.position.y, newPiece.transform.position.z);
        newPiece.Initialize(playerProgressTracker);
    }

    private bool PoolIsNull()
    {
        if (Managers.PiecesObjectPooler.Pool == null)
            return true;

        return false;
    }

    private IEnumerator _Spawner()
    {
        yield return new WaitUntil(() => Managers.GameManager.GameState == GameStates.PlayState);

        while (Managers.GameManager.GameState == GameStates.PlayState)
        {
            SpawnPiece();
            yield return new WaitUntil(() => newPiece.IsPlaced);
        }
    }

}
