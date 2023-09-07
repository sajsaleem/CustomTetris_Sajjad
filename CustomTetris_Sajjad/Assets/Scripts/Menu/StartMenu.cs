using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : BaseMenu
{
    public override void Init()
    {
        base.Init();
        SetSelectablesActiveStatus(false);
    }

    public void OnSinglePlayerStartCallBack()
    {
        Managers.GameManager.StartLevelSequence(GameModeType.SinglePlayer);
        Managers.MenuController.DisableUi(MenuType);
    }

    public void OnTwoPlayerStartCallBack()
    {
        Managers.GameManager.StartLevelSequence(GameModeType.TwoPlayer);
        Managers.MenuController.DisableUi(MenuType);
    }

    public override void SetSelectablesActiveStatus(bool value)
    {
        base.SetSelectablesActiveStatus(value);
    }

    public override void MyEnable()
    {
        base.MyEnable();

        SetSelectablesActiveStatus(true);
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }
}
