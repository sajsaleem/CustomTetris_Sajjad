using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalPieceData" , menuName = ConstantsManager.MenuName.ScriptableObjects +"/NormalPieceData")]
public class NormalPiece : BaseBlockSettings
{
    public override float CalculateNormalFallSpeed()
    {
        return blockData.normalFallSpeed * blockData.gravity.y;
    }

    public override float CaclulateFreeFallSpeed()
    {
        return blockData.freefallSpeed * blockData.gravity.y;
    }
}
