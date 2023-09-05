using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlockSettings : ScriptableObject
{
    public blockData blockData;

    public abstract float CalculateNormalFallSpeed();
    public abstract float CaclulateFreeFallSpeed();
}
