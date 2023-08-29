using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(IPiecesObjectPooler))]

public class Managers : MonoBehaviour
{
    private static IPiecesObjectPooler piecesObjectPooler;

    public static PieceSpawner pieceSpawner;

    public static PieceSpawner PieceSpawner => pieceSpawner;


    public static IPiecesObjectPooler PiecesObjectPooler
    {
        get
        {
            if (piecesObjectPooler == null)
                return NullPiecesObjectPooler.Instance;

            return piecesObjectPooler;
        }
            //=> piecesObjectPooler;
    }


    private void Awake()
    {
        piecesObjectPooler = GetComponent<IPiecesObjectPooler>();
        pieceSpawner = FindObjectOfType<PieceSpawner>();
    }
}
