using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalPieceData" , menuName = ConstantsManager.MenuName.ScriptableObjects +"/NormalPieceData")]
public class NormalPiece : BasePieceSettings
{
    public override float CalculateNormalFallSpeed()
    {
        return pieceData.normalFallSpeed * pieceData.gravity;
    }

    public override float CaclulateFreeFallSpeed()
    {
        return pieceData.freefallSpeed * pieceData.gravity;
    }
}
