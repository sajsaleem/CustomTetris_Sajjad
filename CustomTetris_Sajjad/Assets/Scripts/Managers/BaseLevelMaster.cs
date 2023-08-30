using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevelMaster : MonoBehaviour,ILevelMaster
{
    [SerializeField] private LevelType levelType;
    [SerializeField] private List<Transform> surfaces = new List<Transform>();
    [SerializeField] private Transform finishLine;

    public LevelType LevelType { get; }
    public List<Transform> Surfaces { get; }
    public Transform FinishLine { get; }
} 
