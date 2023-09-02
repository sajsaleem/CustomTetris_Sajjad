using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(IPiecesObjectPooler))]

public class Managers : MonoBehaviour
{
    private static IPiecesObjectPooler piecesObjectPooler;
    private static ITowerManager towerManager;
    private static ILevelSpawner levelSpawner;
    private static IGameManager gameManager;

    public static ILevelSpawner LevelSpawner => levelSpawner;


    public static IPiecesObjectPooler PiecesObjectPooler
    {
        get
        {
            if (piecesObjectPooler == null)
                return NullPiecesObjectPooler.Instance;

            return piecesObjectPooler;
        }
    }

    public static ITowerManager TowerManager
    {
        get
        {
            if (towerManager == null)
                return NullTowerManager.Instance;

            return towerManager;
        }
    }

    public static IGameManager GameManager
    {
        get
        {
            if (towerManager == null)
                return NullGameManager.Instance;

            return gameManager;
        }
    }



    private void Awake()
    {
        piecesObjectPooler = GetComponent<IPiecesObjectPooler>();
        towerManager = GetComponent<ITowerManager>();
        gameManager = GetComponent<GameManager>();
    }
}
