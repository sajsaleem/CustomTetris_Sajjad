using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockSpawner
{
    BaseBlockMovementHandler NewBlock { get; }
    void SpawnPiece();

}
