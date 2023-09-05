using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static IBlocksObjectPooler blockObjectsPooler;
    private static IGameManager gameManager;
    private static ILevelMaster levelMaster;
    private static IPlayersSpawner playersSpawner;
    private static IMenuController menuController;


    public static IBlocksObjectPooler PiecesObjectPooler
    {
        get
        {
            if (blockObjectsPooler == null)
                return NullBlocksObjectPooler.Instance;

            return blockObjectsPooler;
        }
    }

    public static IGameManager GameManager
    {
        get
        {
            if (gameManager == null)
                return NullGameManager.Instance;

            return gameManager;
        }
    }

    public static ILevelMaster LevelMaster
    {
        get
        {
            if (levelMaster == null)
            {
                return NullLevelMaster.Instance;
            }

            return levelMaster;
        }
    }

    public static IPlayersSpawner PlayersSpawner
    {
        get
        {
            if (levelMaster == null)
                return NullPlayersSpawner.Instance;

            return playersSpawner;
        }
    }

    public static IMenuController MenuController
    {
        get
        {
            if (menuController == null)
                return NullMenuController.Instance;

            return menuController;
        }
    }



    private void Awake()
    {
        blockObjectsPooler = GetComponent<IBlocksObjectPooler>();
        gameManager = GetComponent<IGameManager>();
        levelMaster = GetComponent<ILevelMaster>();
        playersSpawner = GetComponent<IPlayersSpawner>();
        menuController = GetComponent<MenuController>();
    }
}
