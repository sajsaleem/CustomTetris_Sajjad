using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlockSettings : ScriptableObject
{
    public BlockData blockData;

    public abstract float CalculateNormalFallSpeed();
}



