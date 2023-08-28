using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseReturnToPool : MonoBehaviour, IReturnToPool
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public virtual void Initialize()
    {

    }

    public virtual void OnOutOfBounds()
    {

    }
}
