using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullCameraMaster : ICameraMaster
{
    public static NullCameraMaster _instance;

    public static NullCameraMaster Instance
    {
        get
        {
            if (_instance == null)
                return new NullCameraMaster();

            return _instance;
        }
    }

    public void Initialize()
    {

    }

    public void ShowFinishLine(float value)
    {

    }

    public void MoveUp(PlayerTags tag, float height)
    {

    }

    public void MoveDown(PlayerTags tag, float height)
    {

    }

    public void SetCamerasActiveStatus(GameModeType gameModeType)
    {

    }

    public void Reset()
    {

    }
}
