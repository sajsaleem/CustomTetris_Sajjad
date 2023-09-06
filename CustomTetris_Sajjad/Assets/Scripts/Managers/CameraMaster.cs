using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaster : MonoBehaviour,ICameraMaster
{
    [SerializeField] private GameObject cameraForPlayer1;
    [SerializeField] private GameObject cameraForPlayer2;

    private ICameraController cameraControllerPlayer1, cameraControllerPlayer2;

    public void Initialize()
    {
        if (cameraForPlayer1 != null)
            cameraControllerPlayer1 = cameraForPlayer1.GetComponent<ICameraController>();

        if (cameraForPlayer2 != null)
            cameraControllerPlayer2 = cameraForPlayer2.GetComponent<ICameraController>();

        if (cameraControllerPlayer1 != null)
            cameraControllerPlayer1.Initialize();

        if (cameraControllerPlayer2 != null)
            cameraControllerPlayer2.Initialize();
    }

    public void ShowFinishLine(float finishLineYPos)
    {
        ShowPlayer1FinishLine(finishLineYPos);
        ShowPlayer2FinishLine(finishLineYPos);
    }

    public void SetCamerasActiveStatus(GameModeType gameModeType)
    {
        if (cameraForPlayer2 == null)
            return;

        if (gameModeType == GameModeType.TwoPlayer)
            cameraForPlayer2.SetActive(true);
        else
            cameraForPlayer2.SetActive(false);
    }


    public void MoveUp(PlayerTags playerTag, float height)
    {
        switch(playerTag)
        {
            case PlayerTags.Player1:
                if (cameraControllerPlayer1 != null && cameraForPlayer1.activeInHierarchy)
                    cameraControllerPlayer1.MoveUp(height);
                break;

            case PlayerTags.Player2:
                if (cameraControllerPlayer1 != null && cameraForPlayer1.activeInHierarchy)
                    cameraControllerPlayer2.MoveUp(height);
                break;
        }
    }

    public void MoveDown(PlayerTags playerTag, float height)
    {
        switch (playerTag)
        {
            case PlayerTags.Player1:
                if (cameraControllerPlayer1 != null && cameraForPlayer1.activeInHierarchy)
                    cameraControllerPlayer1.MoveUp(height);
                break;

            case PlayerTags.Player2:
                if (cameraControllerPlayer1 != null && cameraForPlayer1.activeInHierarchy)
                    cameraControllerPlayer2.MoveUp(height);
                break;
        }
    }

    public void Reset()
    {
        if (cameraForPlayer1 != null && cameraControllerPlayer1 != null)
            cameraControllerPlayer1.Reset();
        if (cameraForPlayer2 != null && cameraControllerPlayer2 != null)
            cameraControllerPlayer1.Reset();
    }

    private void ShowPlayer1FinishLine(float finishLineYPos)
    {
        if (cameraControllerPlayer1 != null && cameraForPlayer1.activeInHierarchy)
            cameraControllerPlayer1.ShowFinishLine(finishLineYPos);
    }

    private void ShowPlayer2FinishLine(float finishLineYPos)
    {
        if (cameraControllerPlayer2 != null && cameraForPlayer2.activeInHierarchy)
            cameraControllerPlayer2.ShowFinishLine(finishLineYPos);
    }
}
