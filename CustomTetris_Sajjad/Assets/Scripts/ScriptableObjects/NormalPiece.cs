using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalPieceData" , menuName = ConstantsManager.MenuName.ScriptableObjects +"/NormalPieceData")]
public class NormalPiece : BasePieceSettings
{
    public override float CalculateSpeed()
    {
        return pieceData.normalFallSpeed * pieceData.gravity;
    }
}
