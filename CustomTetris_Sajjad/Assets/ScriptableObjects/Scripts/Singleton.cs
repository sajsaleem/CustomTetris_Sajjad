using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T:Component
{
    public static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<T>();

                //if (instance == null)
                //{
                //    GameObject newObj = new GameObject();

                //    if (newObj.GetComponent<T>() != null)
                //        instance = newObj.AddComponent<T>();
                //}
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this as T;

        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
    }
}
