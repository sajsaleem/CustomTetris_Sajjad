using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : BaseMenu
{
    public override void Init()
    {
        base.Init();
        SetSelectablesActiveStatus(false);
    }

    public void OnBackButtonCallBack()
    {
        Managers.MenuController.DisableUi(MenuType);
        Time.timeScale = 1;

    }

    public void OnHomeButtonCallBack()
    {
        Managers.MenuController.ActivateUi(MenuType.StartMenu);
        Managers.MenuController.DisableUi(MenuType);
        Managers.GameManager.ResetAll();
    }

    public override void SetSelectablesActiveStatus(bool value)
    {
        base.SetSelectablesActiveStatus(value);
    }

    public override void MyEnable()
    {
        base.MyEnable();

        SetSelectablesActiveStatus(true);
        Time.timeScale = 0;
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }
}
