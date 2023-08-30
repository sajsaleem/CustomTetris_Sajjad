using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculationsStaticClass
{
    public static Vector2 GetScreenBounds()
    {
        //return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }

    public static float GetVerticalDistance(float value, float referenceYPosition, Vector3 referenceObjectScale)
    {
        float pointOfOrigin = referenceYPosition + (referenceObjectScale.y / 2);
        return value + pointOfOrigin;
    }
}
