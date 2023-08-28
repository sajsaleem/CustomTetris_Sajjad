using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PiecesObjectPooler))]

public class Managers : MonoBehaviour
{
    private static PiecesObjectPooler piecesObjectPooler;

    public static PiecesObjectPooler PiecesObjectPooler
    {
        get => piecesObjectPooler;
    }

    private void Awake()
    {
        piecesObjectPooler = GetComponent<PiecesObjectPooler>();
    }
}
