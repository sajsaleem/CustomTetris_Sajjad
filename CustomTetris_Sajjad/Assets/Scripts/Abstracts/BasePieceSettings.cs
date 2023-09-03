using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePieceSettings : ScriptableObject
{
    public PieceData pieceData;

    public abstract float CalculateNormalFallSpeed();
    public abstract float CaclulateFreeFallSpeed();
}
