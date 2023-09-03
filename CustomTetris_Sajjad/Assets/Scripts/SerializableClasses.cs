using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PieceData
{
    public float normalFallSpeed = default;
    public float freefallSpeed = default;
    public float rotationSpeed = default;
    public float targetRotation = default;
    public Vector3 gravity = Physics.gravity;
    public Vector3 localScale = Vector3.one;
}

[Serializable]
public class LevelData
{
    public Vector3 surfaceDimensions = default;
    public Vector3 surfacePosition = default;
    public int winCondition = default;
    public int lossCondition = default;

    [HideInInspector] public bool isUsed = default;
    //public BaseLevelMaster levelPrefab;
    //[HideInInspector] public bool isInstantiated = default;
}
