using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPropertiesUpdateStaticClass : MonoBehaviour
{
    public static GameObject CreateNewGameObject(string name = "")
    {
        GameObject newObject = new GameObject(name);
        //newParent.transform.position = Vector3.zero;
        return newObject;
    }

    public static Transform InstantiateObject(GameObject toInstantiateObject)
    {
        GameObject newObject = Instantiate(toInstantiateObject);
        //newSurface.transform.localScale = _levelData.surfaceDimensions;
        //newSurface.transform.position = _levelData.surfacePosition;
        return newObject.transform;
    }

    public static void UpdateObjectPosition(Transform toUpdateTransform, Vector3 value)
    {
        toUpdateTransform.position = value;
    }

    public static void UdpateObjectScale(Transform toUpdateTransform, Vector3 value)
    {
        toUpdateTransform.localScale = value;
    }

    public static void UpdateYPosition(Transform toUpdateTransform, float yValue)
    {
        toUpdateTransform.position = new Vector3(toUpdateTransform.position.x, yValue, toUpdateTransform.position.z);
    }

    public static void UpdateXPosition(Transform toUpdateTransform, float xValue)
    {
        toUpdateTransform.position = new Vector3(xValue, toUpdateTransform.position.y, toUpdateTransform.position.z);
    }
}
