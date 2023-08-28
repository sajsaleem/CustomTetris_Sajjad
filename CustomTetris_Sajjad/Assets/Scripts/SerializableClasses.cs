using System;
using UnityEngine;

[Serializable]
public class PieceData
{
    public float normalFallSpeed = default;
    public float freefallSpeed = default;
    public float rotationSpeed = default;
    public float targetRotation = default;
    public float gravity = Physics.gravity.y;
    public Vector3 localScale = Vector3.one;
}
