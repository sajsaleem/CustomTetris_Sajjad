using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelMaster
{
    LevelType LevelType { get; }
    List<Transform> Surfaces { get; }
    Transform FinishLine { get; }
}
