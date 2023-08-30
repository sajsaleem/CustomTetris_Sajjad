using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : BaseLevelSpawner
{
    // Start is called before the first frame update
    void Start()
    {
        InstantiateLevelPrefab(LevelType.SinglePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
