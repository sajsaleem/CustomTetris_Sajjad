using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BlockSpawner : MonoBehaviour,IBlockSpawner
{
    private float leftPositionX , rightPositionX;
    private float spawnHeight = default;

    private Vector3 worldPosition;

    [SerializeField] private UnityLayers unityLayer;
    //[SerializeField] private Transform blockSpawner;

    private IPlayerProgressTracker playerProgressTracker;


    //private BaseBlockMovementHandler newPiece;

    public BaseBlockMovementHandler NewBlock { get; private set; } = default;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 horizontalSpawnArea = Managers.LevelMaster.GetLevel().horizontalSpawnArea;
        leftPositionX = CalculationsStaticClass.GetHorizontalViewportToWorldPoint(horizontalSpawnArea.x);
        rightPositionX = CalculationsStaticClass.GetHorizontalViewportToWorldPoint(horizontalSpawnArea.y);
        spawnHeight = CalculationsStaticClass.GetVerticalViewportToWorldPoint( Managers.LevelMaster.GetLevel().spawnHeight);
        playerProgressTracker = GetComponent<IPlayerProgressTracker>();
        StartCoroutine(_Spawner());
    }


    public void SpawnPiece()
    {
        if (PoolIsNull())
            return;

        NewBlock = Managers.PiecesObjectPooler.Pool.Get();
        NewBlock.gameObject.layer = (int)unityLayer;
        float randomXPosition = Random.Range(leftPositionX, rightPositionX);
        NewBlock.transform.position = new Vector3(randomXPosition, spawnHeight, NewBlock.transform.position.z);
        NewBlock.Initialize(playerProgressTracker);
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
            yield return new WaitUntil(() => NewBlock.IsPlaced);
        }
    }

}
