using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    //[SerializeField] private Transform test;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [ContextMenu("ManualPlace")]
    public void TestPosition()
    {
        //test.position = new Vector3(test.position.x, 40, test.position.z);
    }
}
