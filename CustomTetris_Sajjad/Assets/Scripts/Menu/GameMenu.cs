using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : BaseMenu
{
    //[SerializeField] private Camera miniMapCamera; // camera that renders player2's gameplay on a minimap;
    [SerializeField] private GameObject miniMap; // RawImage that uses RenderTexture for camera rending the player2 level;
    [SerializeField] private GameObject pauseHud;

    public override void Init()
    {
        base.Init();
        SetSelectablesActiveStatus(false);
    }

    public void OnPauseCallback()
    {
        Managers.MenuController.ActivateUi(MenuType.Pause);
    }

    public override void SetSelectablesActiveStatus(bool value)
    {
        base.SetSelectablesActiveStatus(value);
    }

    public override void MyEnable()
    {
        base.MyEnable();

        SetSelectablesActiveStatus(true);

        switch(Managers.GameManager.ActiveGameMode)
        {
            case GameModeType.SinglePlayer:
                SetPauseButtonActiveStatus(true);
                SetMiniMapCameraActiveStatus(false);
                SetMiniMapActiveStatus(false);
                break;
            case GameModeType.TwoPlayer:
                SetMiniMapActiveStatus(true);
                SetMiniMapCameraActiveStatus(true);
                SetPauseButtonActiveStatus(false);
                break;
        }
    }

    public override void Reset()
    {
        //if (miniMapCamera.gameObject.activeInHierarchy)
        //    miniMapCamera.gameObject.SetActive(false);

        throw new System.NotImplementedException();
    }

    // Disable pause button for two player mode so that user is not able to pause the game;
    private void SetPauseButtonActiveStatus(bool value)
    {
        pauseHud.SetActive(value);
    }

    private void SetMiniMapCameraActiveStatus(bool value)
    {
        //miniMapCamera.gameObject.SetActive(value);

    }

    private void SetMiniMapActiveStatus(bool value)
    {
        miniMap.gameObject.SetActive(value);
    }
}
