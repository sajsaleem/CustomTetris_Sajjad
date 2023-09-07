using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BlockSpawner : MonoBehaviour,IBlockSpawner
{
    [SerializeField] private Transform placementHighlighter;
    [SerializeField] private UnityLayers unityLayer;

    private float leftPositionX , rightPositionX;
    private float spawnHeight = default;
    private Vector3 worldPosition;
    private IPlayerProgressTracker playerProgressTracker;

    public BaseBlockMovementHandler NewBlock { get; private set; } = default;


    private void OnEnable()
    {
        Vector2 horizontalSpawnArea = Managers.LevelMaster.GetLevel().horizontalSpawnArea;
        leftPositionX = CalculationsStaticClass.GetHorizontalViewportToWorldPoint(horizontalSpawnArea.x);
        rightPositionX = CalculationsStaticClass.GetHorizontalViewportToWorldPoint(horizontalSpawnArea.y);
        playerProgressTracker = GetComponent<IPlayerProgressTracker>();
        SetPlacementHiglighterActiveStatus(false);
        StartCoroutine(_Spawner());
    }

    private void OnDisable()
    {
        StopCoroutine(_Spawner());
    }


    public void SpawnPiece()
    {
        if (PoolIsNull())
            return;

        spawnHeight = CalculationsStaticClass.GetVerticalViewportToWorldPoint(Managers.LevelMaster.GetLevel().spawnHeight);
        AdjustPlacementHighlighterHeight();

        NewBlock = Managers.BlockObjectsPooler.Pool.Get();
        NewBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Transform[] children = NewBlock.GetComponentsInChildren<Transform>();
        Managers.BlockObjectsPooler.SetParent(NewBlock.transform);

        for(int i =0; i < children.Length; i++)
        {
            children[i].gameObject.layer = (int)unityLayer;
        }

        float randomXPosition = Random.Range(leftPositionX, rightPositionX);
        NewBlock.transform.position = new Vector3(randomXPosition, spawnHeight, NewBlock.transform.position.z);
        NewBlock.Initialize(playerProgressTracker, placementHighlighter);
        SetPlacementHiglighterActiveStatus(true);

    }

    private bool PoolIsNull()
    {
        if (Managers.BlockObjectsPooler.Pool == null)
            return true;

        return false;
    }

    private void AdjustPlacementHighlighterHeight()
    {
        float camHeight = CalculationsStaticClass.GetVerticalViewportToWorldPoint(1);
        float surfaceHeight = Managers.LevelMaster.SurfaceHeight()/1.5f;

        float difference = camHeight - surfaceHeight;

        placementHighlighter.localScale = new Vector3(placementHighlighter.localScale.x, difference, placementHighlighter.localScale.z);
    }

    private void SetPlacementHiglighterActiveStatus(bool value)
    {
        placementHighlighter.gameObject.SetActive(value);
    }

    private IEnumerator _Spawner()
    {
        yield return new WaitUntil(() => Managers.GameManager.GameState == GameStates.PlayState);

        while (Managers.GameManager.GameState == GameStates.PlayState)
        {
            SpawnPiece();
            yield return new WaitUntil(() => NewBlock.IsPlaced || NewBlock.BlockState == BlockState.FellOutOfBounds);
            SetPlacementHiglighterActiveStatus(false);

        }

        yield break;
    }

}
