using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevelMaster : MonoBehaviour,ILevelMaster
{
    [SerializeField] private LevelType levelType;
    [SerializeField] private List<Transform> surfaces = new List<Transform>();
    [SerializeField] private Transform finishLine;
    [SerializeField] private LevelSettings levelSettings;

    //public LevelType LevelType { get; }
    public List<Transform> Surfaces { get; }
    public Transform FinishLine { get; }   
    public BaseLevelSettings LevelSettings { get; }
    public bool IsInstantiated { get; set; }

    public virtual void Initialize()
    {

        int surfacesIndex = 0;

        surfaces.ForEach(
            obj =>
            {
                obj.position = LevelSettings.level.surfacePosition[surfacesIndex];
                obj.localScale = LevelSettings.level.surfaceDimensions;
                surfacesIndex++;
            });


        float finishLineYPos = CalculationsStaticClass.GetVerticalDistance(LevelSettings.level.winCondition, GetMaxYPositionFromList(surfaces), GetObjectYScale(surfaces[0]));
        finishLine.position = new Vector3(finishLine.position.x, finishLineYPos, finishLine.position.z);
    }

    private float GetMaxYPositionFromList(List<Transform> transforms)
    {
        float max = default;

        transforms.ForEach(
            obj =>
            {
                if (obj.position.y > max)
                    max = obj.position.y;
            });
        
        return max;

    }

    private float GetObjectYScale(Transform _transform)
    {
        return _transform.localScale.y;
    }
} 
