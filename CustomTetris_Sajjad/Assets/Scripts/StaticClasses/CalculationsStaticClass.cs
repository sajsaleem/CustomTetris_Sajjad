using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class CalculationsStaticClass
{
    public static Vector2 GetScreenBounds()
    {
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

    public static float GetMaxHeightOfObject(float height, float posY)
    {
        return posY + (height / 2);
    }

    public static float GetVerticalViewportToWorldPoint(float value)
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0, value, 0));
        return pos.y;
    }

    public static float GetHorizontalViewportToWorldPoint(float value)
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(value, 0, 0));
        return pos.x;
    }

    public static float GetHorizontalChilrenScale(Transform _transform)
    {
        float minX = Mathf.Infinity;
        float maxX = -Mathf.Infinity;

        foreach (Transform child in _transform)
        {
            var col = child.GetComponent<BoxCollider>();
            if (col != null)
            {
                if (col.bounds.max.x > maxX) maxX = col.bounds.max.x;
                if (col.bounds.min.x < minX) minX = col.bounds.min.x;
            }
        }

        return maxX - minX;
    }

    public static float GetVerticalChildrenScale(Transform _transform)
    {
        float minY = Mathf.Infinity;
        float maxY = -Mathf.Infinity;

        foreach (Transform child in _transform)
        {
            var col = child.GetComponent<BoxCollider>();
            if (col != null)
            {

                if (col.bounds.max.y > maxY) maxY = col.bounds.max.y;
                if (col.bounds.min.y < minY) minY = col.bounds.min.y;
            }
        }

        Debug.Log("Height: " + (maxY - minY));

        return maxY - minY;
    }
}
 