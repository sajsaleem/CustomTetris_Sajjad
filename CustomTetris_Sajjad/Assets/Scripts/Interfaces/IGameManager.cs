using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    void StartPlay(LevelType levelType);
    void EndPlay();
}
