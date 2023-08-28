using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenBoundsStaticClass
{
    public static Vector2 GetScreenBounds()
    {
        //return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }
}
