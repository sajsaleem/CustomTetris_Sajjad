using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class CalculationsStaticClass
{
    public static Vector2 GetScreenBounds()
    {
        //return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }

    public static float GetVerticalDistance(float value, float referenceYPosition, float refObjectYScale)
    {
        float pointOfOrigin = referenceYPosition + (refObjectYScale / 2);
        return value + pointOfOrigin;
    }

    public static Transform GetHeighestTransformInChildren(Transform parent)
    {

        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Transform max = children[1]; // 0 index is always a parent so initially storing first child Transform as max at index 1;

        for(int i = 2; i < children.Length; i++)
        {
            if (children[i].position.y > max.position.y)
                max = children[i];
        }

        return max;
    }

    public static float GetObjectHeight(Transform _transform)
    {
        float posY = _transform.position.y;

        return posY + (_transform.localScale.y / 2);
    }
}
 