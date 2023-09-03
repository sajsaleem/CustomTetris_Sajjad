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
    public Vector2 horizontalSpawnArea; // 0 left , 1 right in X-Axis in normalized Viewport;
    public float spawnHeight = default; // 1 top of the screen in normalized Viewport;
    public int winCondition = default;
    public int lossCondition = default;

    [HideInInspector] public bool isUsed = default;
}
